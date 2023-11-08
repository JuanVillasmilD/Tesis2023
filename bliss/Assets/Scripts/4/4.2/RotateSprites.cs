using UnityEngine;
using System.Collections;

public class RotateSprites : MonoBehaviour
{
    [SerializeField]
    private float rotationAngle = 90f; // Ángulo de rotación predeterminado
    [SerializeField]
    private float rotationSpeed = 150f; // Velocidad de rotación
    [SerializeField]
    private AudioClip rotationSound1; // Primer sonido de rotación
    [SerializeField]
    private AudioClip rotationSound2; // Segundo sonido de rotación

    private bool isRotating = false; // Variable para rastrear si la rotación está en curso

    private AudioSource audioSource;

    public GameObject objetoDeControl; // Asigna el GameObject desde el Inspector.


    private void Start()
    {
        // Obtén el componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!isRotating && !objetoDeControl.activeSelf)
        {
            StartCoroutine(RotateSmoothly());
        }
    }

    private IEnumerator RotateSmoothly()
    {
        isRotating = true;
        float currentRotation = transform.eulerAngles.z;
        float targetRotation = currentRotation + rotationAngle;

        // Selecciona aleatoriamente entre los dos sonidos
        AudioClip selectedSound = Random.Range(0, 2) == 0 ? rotationSound1 : rotationSound2;

        // Reproduce el sonido de rotación seleccionado
        if (audioSource != null && selectedSound != null)
        {
            audioSource.PlayOneShot(selectedSound);
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
