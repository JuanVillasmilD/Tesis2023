using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeControl : MonoBehaviour
{
    private bool isPaused = true; // Inicialmente, la escena está pausada
    public Button toggleButton; // Referencia al botón en el Canvas
    public TextController textController; // Referencia al TextController

    void Start()
    {
        // Establece la velocidad de tiempo en 0 al inicio
        Time.timeScale = 0;

        // Asigna la función al evento de clic del botón
        toggleButton.onClick.AddListener(ToggleTimeScale);
    }

    void ToggleTimeScale()
    {
        isPaused = !isPaused; // Cambia el estado de pausa

        if (isPaused)
        {
            Time.timeScale = 0; // Congela la escena
        }
        else
        {
            Time.timeScale = 1; // Restaura la velocidad normal de la escena
        }

        // Llama a la función ToggleAnimation en el TextController para pausar o reanudar la animación de fade
        textController.ToggleAnimation(isPaused);
    }
}
