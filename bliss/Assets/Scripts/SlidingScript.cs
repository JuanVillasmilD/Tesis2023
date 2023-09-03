using UnityEngine;

public class SlidingScript : MonoBehaviour
{
    [SerializeField]
    private Transform emptySpace = null;
    private Camera _camera;

    [SerializeField]
    private TilesScript[] tiles;
    private int emptySpaceIndex = 15;

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
    }

    public void Shuffle()
    {
        for (int i = 0; i <= 14; i++)
        {
            var lastPos = tiles[i].targetPosition;
            int randomIndex = Random.Range(0, 14);
            tiles[i].targetPosition = tiles[randomIndex].targetPosition;
            tiles[randomIndex].targetPosition = lastPos;
            var tile = tiles[i];
            tiles[i] = tiles[randomIndex];
            tiles[randomIndex] = tile;
        }
        
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
}
