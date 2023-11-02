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
    private int emptySpaceIndex = 8;
    private bool _isFinished;

    [SerializeField]
    private GameObject endPanel;

    [SerializeField]
    private TextMeshProUGUI moveCountText;

    private int moveCount = 0;
    private int score = 6000;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private float elapsedTime = 0f;

    [SerializeField]
    private TextMeshProUGUI endPanelTimeText;

    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }

    void Update()
    {
        if (score > 0 && !_isFinished)
        {
            elapsedTime += Time.deltaTime;
        }

        if (score > 0 && Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 1.5)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;

                    // Incrementa el contador de movimientos
                    moveCount++;

                    // Resta 20 puntos del puntaje por cada movimiento
                    score -= 20;

                    // Actualiza el texto del contador de movimientos en el componente TMP
                    moveCountText.text = moveCount.ToString();

                    // Actualiza el texto del puntaje en el componente TMP
                    scoreText.text = score.ToString() + "pts";
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
                // Muestra el puntaje en el EndPanel
                scoreText.text = score.ToString() + "pts";

                // Calcula el tiempo en formato 00:00
                var a = GetComponent<TimerScript>();
                a.StopTimer();
                int minutes = Mathf.FloorToInt(elapsedTime / 60);
                int seconds = Mathf.FloorToInt(elapsedTime % 60);
                string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

                // Muestra el tiempo en el EndPanel
                endPanelTimeText.text = timeString;

                SaveData(); // Llama a la función para guardar los datos
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Shuffle()
    {
        if (emptySpaceIndex != 8)
        {
            var tileOn11LastPos = tiles[8].targetPosition;
            tiles[8].targetPosition = emptySpace.position;
            emptySpace.position = tileOn11LastPos;
            tiles[emptySpaceIndex] = tiles[8];
            tiles[8] = null;
            emptySpaceIndex = 11;
        }
        int inversion;
        do
        {
            for (int i = 0; i <= 7; i++)
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 7);
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

    void SaveData()
    {
        // Obtener los 3 mejores puntajes y tiempos almacenados anteriormente.
        float[] mejoresPuntajesSE = new float[3];
        float[] mejoresTiemposSE = new float[3];

        for (int i = 0; i < 3; i++)
        {
            mejoresPuntajesSE[i] = PlayerPrefs.GetFloat($"MejorPuntajeSE{i}", float.MinValue);
            mejoresTiemposSE[i] = PlayerPrefs.GetFloat($"MejorTiempoSE{i}", float.MaxValue);
        }

        // Comprobar si el puntaje actual es mejor que los puntajes almacenados.
        for (int i = 0; i < 3; i++)
        {
            if (score > mejoresPuntajesSE[i])
            {
                float tempPuntaje = mejoresPuntajesSE[i];
                float tempTiempo = mejoresTiemposSE[i];

                mejoresPuntajesSE[i] = score;
                mejoresTiemposSE[i] = elapsedTime;

                score = (int)tempPuntaje; // Establece el puntaje actual al puntaje sobrescrito
                elapsedTime = tempTiempo; // Establece el tiempo actual al tiempo sobrescrito
            }
        }

        // Almacenar los tres mejores puntajes y tiempos.
        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetFloat($"MejorPuntajeSE{i}", mejoresPuntajesSE[i]);
            PlayerPrefs.SetFloat($"MejorTiempoSE{i}", mejoresTiemposSE[i]);
        }

        PlayerPrefs.Save(); // Guarda los datos
    }
}
