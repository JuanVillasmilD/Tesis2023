using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // add this for the All search with the LIST

public class GridManager : MonoBehaviour
{
    int[,] grid;
    int vertical,
        horizontal,
        columns,
        rows;
    public Sprite fullBubble;
    public Sprite poppedBubble;
    public AudioSource sound;
    public GameObject particles;
    List<GameObject> bubbleCollection = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = vertical * Screen.width / Screen.height;
        columns = horizontal * 3;
        rows = vertical * 2;
        grid = new int[columns, rows];
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                SpawnBubbles(i, j);
            }
        }
    }

    private void SpawnBubbles(int x, int y)
    {
        GameObject tempObject = new GameObject("X" + x + "Y" + y);
        tempObject.transform.position = new Vector2(x - (horizontal + .5f), y - (vertical - .5f));
        var tempSprite = tempObject.AddComponent<SpriteRenderer>();
        var tempCollider = tempObject.AddComponent<BoxCollider>();
        tempSprite.sprite = fullBubble;
        bubbleCollection.Add(tempObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                SpriteRenderer hitSpriteRenderer =
                    hit.transform.gameObject.GetComponent<SpriteRenderer>();
                if (hitSpriteRenderer.sprite == fullBubble)
                {
                    hitSpriteRenderer.sprite = poppedBubble;
                    sound.Play();
                    GameObject particle = Instantiate(
                        particles,
                        hit.transform.position,
                        Quaternion.identity
                    );
                    particle.GetComponent<ParticleSystem>().Play();
                    if (
                        bubbleCollection.All(
                            o => o.gameObject.GetComponent<SpriteRenderer>().sprite == poppedBubble
                        )
                    )
                    {
                        Debug.Log("All the bubbles are popped!! now resetting");
                        foreach (GameObject x in bubbleCollection.ToList())
                        {
                            x.GetComponent<SpriteRenderer>().sprite = fullBubble;
                        }
                    }
                }
            }
        }
    }
}
