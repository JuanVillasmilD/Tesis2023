using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Referencia al campo de texto TMP para mostrar el temporizador
    public float countdownDuration = 300.0f; // Duración del temporizador en segundos (5 minutos por defecto)
    private float currentTime; // Tiempo actual del temporizador
    private bool isCountingDown; // Indica si el temporizador está en marcha

    private void Start()
    {
        currentTime = countdownDuration;
        isCountingDown = true; // El temporizador comienza automáticamente
        UpdateTimerText();
    }

    private void Update()
    {
        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                isCountingDown = false;
            }

            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        // Formatea el tiempo en minutos y segundos (MM:SS)
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        if (minutes < 0) minutes = 0;
        if (seconds < 0) seconds = 0;

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Actualiza el campo de texto TMP
        timerText.text = formattedTime;
    }

    // Función para detener el temporizador
    public void StopCountdown()
    {
        isCountingDown = false;
        UpdateTimerText(); // Actualiza el texto a "00:00" cuando se detiene
    }

    // Función para reiniciar el temporizador con una nueva duración en segundos
    public void RestartCountdown(float duration)
    {
        countdownDuration = duration;
        currentTime = countdownDuration;
        isCountingDown = true;
        UpdateTimerText();
    }
}
