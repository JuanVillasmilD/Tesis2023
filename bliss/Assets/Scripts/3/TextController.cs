using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Referencia al componente TextMeshProUGUI
    public List<PhraseData> phrases; // Lista de frases y duraciones configurables desde el Inspector
    private int currentIndex = 0; // Índice de la frase actual
    private bool isAnimating = true; // Indicador de si la animación está en curso

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
            // Inicializa el cuadro de texto TMP con la primera frase
            textMeshPro.text = phrases[currentIndex].phrase;
            currentIndex++;
        }

        // Comienza la secuencia de frases
        StartCoroutine(PlayPhrases());
    }

    private IEnumerator PlayPhrases()
    {
        while (currentIndex < phrases.Count)
        {
            // Espera la duración de la frase actual
            yield return new WaitForSeconds(phrases[currentIndex - 1].duration);

            // Verifica si la animación está en curso
            if (isAnimating)
            {
                // Muestra la siguiente frase
                textMeshPro.text = phrases[currentIndex].phrase;
                currentIndex++;
            }
        }
    }

    // Función para pausar o reanudar la animación de fade
    public void ToggleAnimation(bool pause)
    {
        isAnimating = !pause;
    }
}
