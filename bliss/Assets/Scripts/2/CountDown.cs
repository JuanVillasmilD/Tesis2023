using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countDownText; // Objeto TextMeshProUGUI para mostrar la cuenta regresiva
    public TextMeshProUGUI countUpText; // Objeto TextMeshProUGUI para mostrar el contador progresivo
    public float tiempoInicialCountDown = 300.0f; // Tiempo inicial en segundos para la cuenta regresiva
    public float tiempoInicialCountUp = 0.0f; // Tiempo inicial en segundos para el contador progresivo
    public GameObject activarAlTerminar; // GameObject a activar cuando el tiempo llega a 0
    public GameObject desactivarAlTerminar; // GameObject a desactivar cuando el tiempo llega a 0
    public string sceneToLoad;
    public string sceneToLoadOnExit;

    private float tiempoRestanteCountDown;
    private float tiempoRestanteCountUp;
    private float tiempoTranscurridoCountDown;
    private float tiempoTranscurridoCountUp;
    private bool estaPausado = true;

    private void Start()
    {
        tiempoRestanteCountDown = tiempoInicialCountDown;
        tiempoRestanteCountUp = tiempoInicialCountUp;
        tiempoTranscurridoCountDown = 0;
        tiempoTranscurridoCountUp = 0;
        estaPausado = true;
        MostrarCuentaRegresiva();
        MostrarContadorProgresivo();
    }

    private void Update()
    {
        if (!estaPausado)
        {
            tiempoRestanteCountDown -= Time.deltaTime;
            tiempoTranscurridoCountDown += Time.deltaTime;
            
            tiempoRestanteCountUp += Time.deltaTime;
            tiempoTranscurridoCountUp += Time.deltaTime;

            if (tiempoRestanteCountDown <= 0)
            {
                tiempoRestanteCountDown = 0;
                estaPausado = true;
                OnCountDownFinished(); // Llama a la función cuando el tiempo llega a 0
            }

            MostrarCuentaRegresiva();
            MostrarContadorProgresivo();
        }
    }

    public void IniciarCountDown()
    {
        estaPausado = false;
    }

    public void PausarCountDown()
    {
        estaPausado = true;
    }

    private void MostrarCuentaRegresiva()
    {
        int minutos = Mathf.FloorToInt(tiempoRestanteCountDown / 60);
        int segundos = Mathf.FloorToInt(tiempoRestanteCountDown % 60);
        string tiempoFormateado = minutos.ToString("00") + ":" + segundos.ToString("00");
        countDownText.text = "-" + tiempoFormateado;
    }

    private void MostrarContadorProgresivo()
    {
        int minutos = Mathf.FloorToInt(tiempoTranscurridoCountUp / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurridoCountUp % 60);
        string tiempoFormateado = minutos.ToString("00") + ":" + segundos.ToString("00");
        countUpText.text = tiempoFormateado;
    }

    private void OnCountDownFinished()
    {
        // Activa el GameObject especificado al llegar a 0 y desactiva otro
        if (activarAlTerminar != null)
        {
            activarAlTerminar.SetActive(true);
        }
        if (desactivarAlTerminar != null)
        {
            desactivarAlTerminar.SetActive(false);
        }
        // Poner el tiempo de la escena en 0f
        Time.timeScale = 0f;
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f; // Restaura el tiempo a 1f
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
    }

    public void CargarOtroReproductor()
    {
        Time.timeScale = 1f; // Restaura el tiempo a 1f
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitReproductor()
    {
        Time.timeScale = 1f; // Restaura el tiempo a 1f
        SceneManager.LoadScene(sceneToLoadOnExit);
    }
}
