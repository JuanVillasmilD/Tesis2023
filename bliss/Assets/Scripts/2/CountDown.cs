using System;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countDownText; // Objeto TextMeshProUGUI para mostrar la cuenta regresiva
    public TextMeshProUGUI countUpText; // Objeto TextMeshProUGUI para mostrar el contador progresivo
    public float tiempoInicialCountDown = 300.0f; // Tiempo inicial en segundos para la cuenta regresiva
    public float tiempoInicialCountUp = 0.0f; // Tiempo inicial en segundos para el contador progresivo

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
}
