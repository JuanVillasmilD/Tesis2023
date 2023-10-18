using UnityEngine;
using TMPro;

public class Puntajes : MonoBehaviour
{
    public TextMeshProUGUI puntajesTMP;

    private void Start()
    {
        // Recupera los puntajes almacenados en PlayerPrefs.
        float[] puntajes = new float[3];

        for (int i = 0; i < 3; i++)
        {
            puntajes[i] = PlayerPrefs.GetFloat($"MejorPuntaje{i}", float.MaxValue);
        }

        // Formatea los puntajes como texto.
        string puntajesTexto = "";

        for (int i = 0; i < 3; i++)
        {
            if (puntajes[i] != float.MaxValue)
            {
                puntajesTexto += $"{i + 1}. {FormatearTiempo(puntajes[i])}\n\n\n";
            }
        }

        // Actualiza el texto del objeto TMP con los puntajes.
        puntajesTMP.text = puntajesTexto;
    }

    string FormatearTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        return $"{minutos:D2}:{segundos:D2}";
    }
}
