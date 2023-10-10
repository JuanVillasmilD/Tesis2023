using UnityEngine;
using TMPro;
using System;

[System.Serializable]
public class Mensaje {
    public string titulo;
    public string desarrollo;
}

public class GestorMensajes : MonoBehaviour {
    public TextMeshProUGUI tituloText;
    public TextMeshProUGUI desarrolloText;
    public Mensaje[] mensajes;

    private const string UltimoMensajeMostradoKey = "UltimoMensajeMostrado";
    private int indiceMensajeActual = 0;

    private void Start() {
        // Obtiene el día actual y el último mensaje mostrado
        int diaActual = DateTime.Now.Day;
        int ultimoMensajeMostrado = PlayerPrefs.GetInt(UltimoMensajeMostradoKey, -1);

        // Calcula el índice del mensaje a mostrar
        if (ultimoMensajeMostrado >= 0 && ultimoMensajeMostrado < mensajes.Length - 1) {
            indiceMensajeActual = ultimoMensajeMostrado + 1;
        }

        // Actualiza el último mensaje mostrado
        PlayerPrefs.SetInt(UltimoMensajeMostradoKey, indiceMensajeActual);
        PlayerPrefs.Save();

        // Muestra el mensaje actual
        tituloText.text = mensajes[indiceMensajeActual].titulo;
        desarrolloText.text = mensajes[indiceMensajeActual].desarrollo;
    }
}
