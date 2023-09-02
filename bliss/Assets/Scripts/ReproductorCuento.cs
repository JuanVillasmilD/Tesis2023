using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReproductorCuento : MonoBehaviour
{
    public AudioClip cancion;

    private bool reproduciendo = false;
    private AudioSource audioSource;
    private float fadeDuration = 0.5f;
    private float targetVolume = 0f;
    private float fadeSpeed = 0f;

    private void Start()
    {
        // Obtén el componente AudioSource adjunto a este objeto
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = cancion;
    }

    private void Update()
    {
        if (fadeSpeed != 0f)
        {
            audioSource.volume += fadeSpeed * Time.deltaTime;

            if ((fadeSpeed > 0f && audioSource.volume >= targetVolume) || (fadeSpeed < 0f && audioSource.volume <= targetVolume))
            {
                fadeSpeed = 0f;
                audioSource.volume = targetVolume;

                if (targetVolume == 0f)
                {
                    audioSource.Pause();
                }
            }
        }
    }

    public void ToggleReproducirPausar()
    {
        reproduciendo = !reproduciendo;

        if (reproduciendo)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
    }

    private void FadeIn()
    {
        audioSource.volume = 0f;
        audioSource.Play();
        fadeSpeed = 1f / fadeDuration;
        targetVolume = 1f;
    }

    private void FadeOut()
    {
        fadeSpeed = -1f / fadeDuration;
        targetVolume = 0f;
    }
}