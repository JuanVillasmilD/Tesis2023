using UnityEngine;
using TMPro;

public class BubblesManager : MonoBehaviour
{
    private int bombillosEncendidos = 0;
    public TextMeshProUGUI contadorTMP;

    public void DetectarSonido()
    {
        // Implementa aquí la lógica para detectar el sonido.
        bombillosEncendidos++;
        ActualizarContador();
    }

    void ActualizarContador()
    {
        // Actualiza el contador en función de los bombillos encendidos.
        // Puedes mostrarlo en un TextMeshPro, Debug.Log o en cualquier otro lugar.
        contadorTMP.text = ($"{bombillosEncendidos}/60");
    }
}
