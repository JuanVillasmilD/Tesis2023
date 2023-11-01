using UnityEngine;
using TMPro;

public class PuntajesR : MonoBehaviour
{
    public TextMeshProUGUI puntajesTMP;

    private void Start()
    {
        // Recupera los puntajes y tiempos almacenados en PlayerPrefs.
        float[] puntajesR = new float[3];
        float[] tiemposR = new float[3];

        for (int i = 0; i < 3; i++)
        {
            puntajesR[i] = PlayerPrefs.GetFloat($"MejorPuntajeR{i}", float.MaxValue);
            tiemposR[i] = PlayerPrefs.GetFloat($"MejorTiempoR{i}", float.MaxValue);
        }

        // Inicializa la variable puntajesTexto.
        string puntajesTexto = "";

        for (int i = 0; i < 3; i++)
        {
            if (puntajesR[i] != float.MaxValue)
            {
                puntajesTexto += $"{puntajesR[i]}pts - " + $"{FormatearTiempo(tiemposR[i])}";
            }
        }

        // Actualiza el texto del objeto TMP con los puntajes y tiempos.
        puntajesTMP.text = puntajesTexto;
    }

    string FormatearTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        return $"{minutos:D2}:{segundos:D2}";
    }
}
