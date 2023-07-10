using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    public AudioSource audioSource;
    public Image circuloImagen;
    public RectTransform puntoA;
    public RectTransform puntoB;

    private void Update()
    {
        float progreso = 0f;

        if (audioSource.isPlaying)
        {
            progreso = audioSource.time / audioSource.clip.length;
        }

        // Calcula la posición entre los puntos A y B
        Vector3 nuevaPosicion = Vector3.Lerp(puntoA.localPosition, puntoB.localPosition, progreso);

        // Actualiza la posición del círculo de la barra de progreso
        circuloImagen.rectTransform.localPosition = nuevaPosicion;
    }
}