using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Referencia al campo de texto TMP para mostrar el temporizador
    public GameObject elementToDeactivate; // Elemento a desactivar cuando el tiempo llegue a 0
    public GameObject elementToActivate; // Elemento a activar cuando el tiempo llegue a 0
    public Image imageToActivate;

    public float countdownDuration = 300.0f; // Duración del temporizador en segundos (5 minutos por defecto)
    private float currentTime; // Tiempo actual del temporizador
    private bool isCountingDown; // Indica si el temporizador está en marcha

    public string nombreEscena = "";
    public string nombreEscena2 = "";

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

            if (currentTime <= 1)
            {
                currentTime = 0;
                isCountingDown = false;
                StartCoroutine(ActivateImageAndEmptyCoroutine());
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

    private IEnumerator ActivateImageAndEmptyCoroutine()
    {
        elementToDeactivate.SetActive(false);
        // Activa la imagen
        imageToActivate.gameObject.SetActive(true);

        // Espera 0.25 segundos
        yield return new WaitForSeconds(0.25f);

        // Desactiva la imagen
        imageToActivate.gameObject.SetActive(false);

        // Activa el emptyObject
        elementToActivate.SetActive(true);
    }

    public void RepetirEscena()
    {
        // Carga la nueva escena
        SceneManager.LoadScene(nombreEscena);
    }

    public void SalirEscena()
    {
        // Encuentra el objeto TimeManager en la escena actual
        TimeManager timeManager = FindObjectOfType<TimeManager>();

        if (timeManager != null)
        {
            // Establece la velocidad de tiempo a 1 utilizando el TimeManager
            timeManager.SetTimeScale(1);
        }

        // Carga la nueva escena
        SceneManager.LoadScene(nombreEscena2);
    }
}
