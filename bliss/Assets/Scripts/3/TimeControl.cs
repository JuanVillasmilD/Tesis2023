using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TimeControl : MonoBehaviour
{
    private bool isPaused = true; // Inicialmente, la escena está pausada
    public GameObject pauseButton;
    public GameObject resumeButton;
    public TextController textController; // Referencia al TextController

    void Start()
    {
        // Establece la velocidad de tiempo en 0 al inicio
        Time.timeScale = 1;
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausa el tiempo
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);

        // Llama a la función ToggleAnimation en el TextController para pausar o reanudar la animación de fade
        textController.ToggleAnimation(isPaused);
    }

    // Función para reanudar el juego
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);

        // Llama a la función ToggleAnimation en el TextController para pausar o reanudar la animación de fade
        textController.ToggleAnimation(isPaused);
    }
}
