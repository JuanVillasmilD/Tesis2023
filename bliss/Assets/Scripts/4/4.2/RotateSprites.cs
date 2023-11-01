using UnityEngine;
using System.Collections;

public class RotateSprites : MonoBehaviour
{
    [SerializeField]
    private float rotationAngle = 90f; // Ángulo de rotación predeterminado
    [SerializeField]
    private float rotationSpeed = 150f; // Velocidad de rotación
    [SerializeField]
    private AudioClip rotationSound; // Sonido de rotación

    private bool isRotating = false; // Variable para rastrear si la rotación está en curso

    private AudioSource audioSource;

    private void Start()
    {
        // Obtén el componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

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

        // Reproduce el sonido de rotación
        if (audioSource != null && rotationSound != null)
        {
            audioSource.PlayOneShot(rotationSound);
        }

        while (Mathf.Abs(currentRotation - targetRotation) > 0.1f)
        {
            currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            yield return null;
        }

        isRotating = false;
    }
}
