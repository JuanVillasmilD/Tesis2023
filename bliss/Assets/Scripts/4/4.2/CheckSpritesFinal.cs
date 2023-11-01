using UnityEngine;
using TMPro;

public class CheckSpritesFinal : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;
    [SerializeField]
    private GameObject nextLevel;
    [SerializeField]
    private GameObject currentLevel;
    [SerializeField]
    private TextMeshProUGUI timeText; // Agrega el objeto de texto TMP para el tiempo
    [SerializeField]
    private TextMeshProUGUI scoreText; // Agrega el objeto de texto TMP para el puntaje

    private float startTime; // Almacena el tiempo de inicio
    private float elapsedTime; // Almacena el tiempo transcurrido
    private int score = 9000; // Puntaje inicial

    // Define una tolerancia para la comparación
    private float rotationTolerance = 0.01f;

    private bool levelCompleted = false; // Variable para rastrear si el nivel se ha completado

    void Start()
    {
        startTime = Time.time; // Guarda el tiempo de inicio al inicio de la escena
    }

    void Update()
    {
        if (!levelCompleted)
        {
            bool allPicturesCorrect = true;

            foreach (Transform picture in pictures)
            {
                // Compara si la rotación está dentro de la tolerancia
                if (Mathf.Abs(picture.rotation.z) > rotationTolerance)
                {
                    allPicturesCorrect = false;
                    break;
                }
            }

            if (allPicturesCorrect)
            {
                levelCompleted = true;
                nextLevel.SetActive(true);
                currentLevel.SetActive(false);
                elapsedTime = Time.time - startTime; // Calcula el tiempo transcurrido
                DisplayElapsedTime();
                CalculateScore();
                SaveData(); // Llama a la función para guardar los datos
            }
        }
    }

    // Muestra el tiempo transcurrido en el objeto de texto TMP
    void DisplayElapsedTime()
    {
        if (timeText != null)
        {
            timeText.text = elapsedTime.ToString("F2") + " segundos"; // Formatea y muestra el tiempo
        }
    }

    // Calcula el puntaje y lo muestra en el objeto de texto TMP
    void CalculateScore()
    {
        int timePenalty = Mathf.FloorToInt(elapsedTime * 15); // Calcula la penalización de tiempo
        score -= timePenalty; // Resta la penalización al puntaje
        if (score < 0)
        {
            score = 0; // Asegura que el puntaje no sea negativo
        }

        if (scoreText != null)
        {
            scoreText.text = score.ToString() + " pts"; // Muestra el puntaje final
        }
    }

    // Función para guardar el puntaje y el tiempo transcurrido en PlayerPrefs y mantener solo los 3 mejores puntajes.
    void SaveData()
    {
        // Obtener los 3 mejores puntajes y tiempos almacenados anteriormente.
        float[] mejoresPuntajesR = new float[3];
        float[] mejoresTiemposR = new float[3];

        for (int i = 0; i < 3; i++)
        {
            mejoresPuntajesR[i] = PlayerPrefs.GetFloat($"MejorPuntajeR{i}", float.MaxValue);
            mejoresTiemposR[i] = PlayerPrefs.GetFloat($"MejorTiempoR{i}", float.MaxValue);
        }

        // Comprobar si el puntaje actual es mejor que los puntajes almacenados.
        for (int i = 0; i < 3; i++)
        {
            if (score < mejoresPuntajesR[i])
            {
                float tempPuntaje = mejoresPuntajesR[i];
                float tempTiempo = mejoresTiemposR[i];

                mejoresPuntajesR[i] = score;
                mejoresTiemposR[i] = elapsedTime;

                score = (int)tempPuntaje; // Establece el puntaje actual al puntaje sobrescrito
                elapsedTime = tempTiempo; // Establece el tiempo actual al tiempo sobrescrito

                break; // No es necesario seguir verificando si ya se ha encontrado un mejor puntaje.
            }
        }

        // Almacenar los tres mejores puntajes y tiempos.
        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetFloat($"MejorPuntajeR{i}", mejoresPuntajesR[i]);
            PlayerPrefs.SetFloat($"MejorTiempoR{i}", mejoresTiemposR[i]);
        }

        PlayerPrefs.Save(); // Guarda los datos
    }
}
