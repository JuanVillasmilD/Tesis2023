using System.Collections;
using TMPro;
using UnityEngine;

public class ControladorDeLetra : MonoBehaviour
{
    public TextMeshProUGUI campoDeTexto;
    public Frase[] frases; // Arreglo de Frases
    private int indiceFrase = 0;
    private float tiempoTranscurrido = 0.0f;
    private bool estaPausado = true;

    private float tiempoRestante; // Nuevo campo para llevar un seguimiento del tiempo restante en la frase actual

    [System.Serializable]
    public class Frase
    {
        public string texto; // Texto de la frase
        public float duracion; // Duración en pantalla de la frase
    }

    private void Start()
    {
        campoDeTexto.text = "";
        estaPausado = true;
        tiempoRestante = 0.0f; // Inicializa el tiempo restante a 0 al inicio
    }

    private void Update()
    {
        if (!estaPausado)
        {
            tiempoTranscurrido += Time.deltaTime;

            if (tiempoTranscurrido >= tiempoRestante)
            {
                MostrarSiguienteFrase();
            }
        }
    }

    public void Reproducir()
    {
        estaPausado = false;

        // Verificar si es la primera frase antes de mostrarla
        if (indiceFrase == 0)
        {
            MostrarSiguienteFrase(); // Muestra la primera frase al presionar "Play"
        }
    }

    public void Pausar()
    {
        estaPausado = true;
    }

    private void MostrarSiguienteFrase()
    {
        if (indiceFrase < frases.Length)
        {
            campoDeTexto.text = frases[indiceFrase].texto;
            tiempoTranscurrido = 0.0f;
            tiempoRestante = frases[indiceFrase].duracion;
            indiceFrase++;
        }
    }
}
