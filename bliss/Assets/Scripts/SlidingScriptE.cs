using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SlidingScriptE : MonoBehaviour
{
    [SerializeField]
    private Transform emptySpace = null;
    private Camera _camera;

    [SerializeField]
    private TilesScript[] tiles;
    private int emptySpaceIndex = 8; // Cambiar el índice del espacio vacío a 8
    private bool _isFinished;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI endPanelTimeText;

    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 1.2)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }
        }
        if (!_isFinished)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                        correctTiles++;
                }
            }

            if (correctTiles == tiles.Length - 1)
            {
                _isFinished = true;
                endPanel.SetActive(true);
                var a = GetComponent<TimerScript>();
                a.StopTimer();
                endPanelTimeText.text = (a.minutes < 10 ? "0" : "") + a.minutes + ":" + (a.seconds < 10 ? "0" : "") + a.seconds;
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Shuffle()
    {
        if (emptySpaceIndex != 8) // Cambiar la comprobación al nuevo índice del espacio vacío
        {
            var tileOn8LastPos = tiles[8].targetPosition; // Cambiar el índice a 8
            tiles[8].targetPosition = emptySpace.position;
            emptySpace.position = tileOn8LastPos;
            tiles[emptySpaceIndex] = tiles[8]; // Cambiar el índice a 8
            tiles[8] = null;
            emptySpaceIndex = 8; // Cambiar el índice a 8
        }
        int inversion;
        do
        {
            for (int i = 0; i <= 7; i++) // Cambiar el rango a 7
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 7); // Cambiar el rango a 7
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;
            }
            inversion = GetInversions();
        } while (inversion % 2 != 0);
    }

    public int findIndex(TilesScript ts)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInversion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInversion++;
                    }
                }
            }
            inversionsSum += thisTileInversion;
        }
        return inversionsSum;
    }
}
