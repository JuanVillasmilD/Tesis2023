using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateSprites : MonoBehaviour
{
    [SerializeField]
    private float rotationAngle = 90f; // Ángulo de rotación predeterminado
    [SerializeField]
    private float rotationSpeed = 150f; // Velocidad de rotación

    private bool isRotating = false; // Variable para rastrear si la rotación está en curso

    private void OnMouseDown()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateSmoothly());
        }
    }

    private IEnumerator RotateSmoothly()
    {
        isRotating = true;
        float currentRotation = transform.eulerAngles.z;
        float targetRotation = currentRotation + rotationAngle;

        while (Mathf.Abs(currentRotation - targetRotation) > 0.1f)
        {
            currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            yield return null;
        }

        isRotating = false;
    }
}
