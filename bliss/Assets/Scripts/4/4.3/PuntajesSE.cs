using UnityEngine;
using TMPro;

public class PuntajesSE : MonoBehaviour
{
    public TextMeshProUGUI puntajesTMP;

    private void Start()
    {
        // Recupera los puntajes y tiempos almacenados en PlayerPrefs.
        float[] puntajesSE = new float[3];
        float[] tiemposSE = new float[3];

        for (int i = 0; i < 3; i++)
        {
            puntajesSE[i] = PlayerPrefs.GetFloat($"MejorPuntajeSE{i}", float.MaxValue);
            tiemposSE[i] = PlayerPrefs.GetFloat($"MejorTiempoSE{i}", float.MaxValue);
        }

        // Inicializa la variable puntajesTexto.
        string puntajesTexto = "";

        for (int i = 0; i < 3; i++)
        {
            if (puntajesSE[i] != float.MaxValue)
            {
                puntajesTexto += $"{puntajesSE[i]}pts - " + $"{FormatearTiempo(tiemposSE[i])}\n\n\n";
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
