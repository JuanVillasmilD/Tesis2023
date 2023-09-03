using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScript : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 correctPosition;
    public int number;
    void Awake()
    {
        targetPosition = transform.position;
        correctPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
    }
}
