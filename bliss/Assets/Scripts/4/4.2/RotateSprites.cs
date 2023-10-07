using UnityEngine;

public class RotateSprites : MonoBehaviour
{
    [SerializeField]
    private float rotationAngle = 90f; // Ángulo de rotación predeterminado

    private void OnMouseDown()
    {
        transform.Rotate(0f, 0f, rotationAngle);
    }
}
