using UnityEngine;
using TMPro;

public class BubblesManager : MonoBehaviour
{
    public GameObject winPanel;
    public TextMeshProUGUI contadorTMP;
    public TextMeshProUGUI tiempoFinalTMP; // Agrega una referencia al objeto TMP para mostrar el tiempo final.

    private int bombillosEncendidos = 0;
    private int totalBombillos = 60;
    private float tiempoTranscurrido = 0f;

    public Temporizador temporizador;

    private void Update()
    {
        if (bombillosEncendidos < totalBombillos)
        {
            tiempoTranscurrido += Time.deltaTime;
        }
    }

    public void DetectarSonido()
    {
        // Implementa aquí la lógica para detectar el sonido.
        bombillosEncendidos++;
        ActualizarContador();

        if (bombillosEncendidos >= totalBombillos)
        {
            JuegoTerminado();
        }
    }

    void ActualizarContador()
    {
        // Actualiza el contador en función de los bombillos encendidos.
        // Puedes mostrarlo en un TextMeshPro, Debug.Log o en cualquier otro lugar.
        contadorTMP.text = ($"{bombillosEncendidos}/60");
    }

    void JuegoTerminado()
    {
        temporizador.JuegoTerminado();
        winPanel.SetActive(true);
        tiempoFinalTMP.text = FormatearTiempo(tiempoTranscurrido);
        // Activa la pantalla de "juego terminado" si no está activa.

        float tiempoActual = tiempoTranscurrido;

        // Guardar el puntaje actual en PlayerPrefs.
        PlayerPrefs.SetFloat("PuntajeActual", tiempoActual);

        // Obtener los puntajes almacenados anteriormente.
        float[] mejoresPuntajes = new float[3];
        for (int i = 0; i < 3; i++)
        {
            mejoresPuntajes[i] = PlayerPrefs.GetFloat($"MejorPuntaje{i}", float.MaxValue);
        }

        // Comprobar si el puntaje actual es mejor que los puntajes almacenados.
        for (int i = 0; i < 3; i++)
        {
            if (tiempoActual < mejoresPuntajes[i])
            {
                float temp = mejoresPuntajes[i];
                mejoresPuntajes[i] = tiempoActual;
                tiempoActual = temp;
            }
        }

        // Almacenar los tres mejores puntajes.
        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetFloat($"MejorPuntaje{i}", mejoresPuntajes[i]);
        }

        PlayerPrefs.Save();
        MostrarMejoresPuntajes();
    }

    string FormatearTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        return $"{minutos:D2}:{segundos:D2}";
    }

    void MostrarMejoresPuntajes()
    {
        string puntajesTexto = "Mejores Puntajes:\n";

        for (int i = 0; i < 3; i++)
        {
            float puntaje = PlayerPrefs.GetFloat($"MejorPuntaje{i}", float.MaxValue);

            if (puntaje != float.MaxValue)
            {
                puntajesTexto += $"{i + 1}. {FormatearTiempo(puntaje)}\n";
            }
        }
    }
}
