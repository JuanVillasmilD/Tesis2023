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

    private const string UltimaFechaCambioKey = "UltimaFechaCambio";
    private const string MensajeActualKey = "MensajeActual";
    private DateTime ultimaFechaCambio;
    private int indiceMensajeActual = 0;

    private void Start() {
        // Obtiene la última fecha de cambio y la fecha actual
        ultimaFechaCambio = DateTime.Parse(PlayerPrefs.GetString(UltimaFechaCambioKey, DateTime.MinValue.ToString()));
        DateTime fechaActual = DateTime.Now;

        // Comprueba si la fecha actual es posterior a la última fecha de cambio
        if (fechaActual.Date > ultimaFechaCambio.Date) {
            // Si la fecha actual es posterior, actualiza el mensaje
            ActualizarMensaje(fechaActual);
        } else {
            // Si no, carga el mensaje actual
            CargarMensajeActual();
        }

        // Muestra el mensaje actual
        tituloText.text = mensajes[indiceMensajeActual].titulo;
        desarrolloText.text = mensajes[indiceMensajeActual].desarrollo;
    }

    private void ActualizarMensaje(DateTime fechaActual) {
        // Guarda la nueva fecha de cambio
        PlayerPrefs.SetString(UltimaFechaCambioKey, fechaActual.ToString());
        PlayerPrefs.Save();

        // Actualiza el mensaje actual
        indiceMensajeActual = (indiceMensajeActual + 1) % mensajes.Length;
        PlayerPrefs.SetInt(MensajeActualKey, indiceMensajeActual);
        PlayerPrefs.Save();
    }

    private void CargarMensajeActual() {
        indiceMensajeActual = PlayerPrefs.GetInt(MensajeActualKey, 0);
    }
}
