using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Referencia al componente TextMeshProUGUI
    public TextMeshProUGUI countdownText; // Referencia al campo de texto TMP para el conteo regresivo

    public List<PhraseData> phrases; // Lista de frases y duraciones configurables desde el Inspector
    private int currentIndex = 0; // Índice de la frase actual
    private bool isAnimating = true; // Indicador de si la animación está en curso
    private float currentTime = 0f; // Tiempo transcurrido desde que se mostró la frase actual

    [System.Serializable]
    public class PhraseData
    {
        public string phrase;
        public float duration;
    }

    private void Start()
    {
        if (phrases.Count > 0)
        {
            // Inicializa el cuadro de texto TMP de las frases con la primera frase
            textMeshPro.text = phrases[currentIndex].phrase;
            currentIndex++;

            // Inicializa el tiempo transcurrido
            currentTime = 0f;
        }

        // Comienza la secuencia de frases
        StartCoroutine(PlayPhrases());
    }

    private IEnumerator PlayPhrases()
    {
        while (currentIndex < phrases.Count)
        {
            // Espera hasta que el tiempo transcurrido alcance la duración de la frase actual
            while (currentTime < phrases[currentIndex - 1].duration)
            {
                if (isAnimating)
                {
                    // Actualiza el cuadro de texto de conteo regresivo
                    int remainingSeconds = Mathf.CeilToInt(phrases[currentIndex - 1].duration - currentTime);
                    countdownText.text = remainingSeconds.ToString();
                    yield return null; // Espera un frame
                    currentTime += Time.deltaTime;
                }
                else
                {
                    yield return null; // Espera un frame si la animación está pausada
                }
            }

            // Muestra la siguiente frase
            textMeshPro.text = phrases[currentIndex].phrase;
            currentIndex++;

            // Restablece el tiempo transcurrido
            currentTime = 0f;

            // Verifica si hay una siguiente frase
            if (currentIndex < phrases.Count)
            {
                // Inicia el conteo regresivo de la duración de la próxima frase
                int remainingSeconds = Mathf.CeilToInt(phrases[currentIndex].duration);
                countdownText.text = remainingSeconds.ToString();
            }
            else
            {
                // No hay más frases, limpia el cuadro de texto de conteo regresivo
                countdownText.text = "";
            }
        }
    }

    // Función para pausar o reanudar la animación
    public void ToggleAnimation(bool pause)
    {
        isAnimating = !pause;
    }
}
