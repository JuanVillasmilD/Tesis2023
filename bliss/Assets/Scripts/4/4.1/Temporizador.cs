using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public TextMeshProUGUI contadorTiempoTMP;
    
    private float tiempoTranscurrido = 0f;
    private bool juegoTerminado = false;

    private void Update()
    {
        if (!juegoTerminado)
        {
            tiempoTranscurrido += Time.deltaTime;
            ActualizarTemporizador();
        }
    }

    void ActualizarTemporizador()
    {
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60f);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60f);

        contadorTiempoTMP.text = $"{minutos:D2}:{segundos:D2}";
    }

    public void JuegoTerminado()
    {
        juegoTerminado = true;
    }
}
