using UnityEngine;
using TMPro;
using System;

public class CheckSpritesFinal : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private GameObject nextLevel;

    [SerializeField]
    private GameObject currentLevel;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private float startTime;
    private float elapsedTime;
    private int score = 9000;
    private float rotationTolerance = 0.01f;
    private bool levelCompleted = false;

    void Start()
    {
        startTime = Time.time;
        // PlayerPrefs.DeleteKey("BestScore0");
        // PlayerPrefs.DeleteKey("BestScore1");
        // PlayerPrefs.DeleteKey("BestScore2");
        // PlayerPrefs.Save(); // Guarda los cambios
    }

    void Update()
    {
        if (!levelCompleted)
        {
            bool allPicturesCorrect = true;

            foreach (Transform picture in pictures)
            {
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

    // Muestra el tiempo transcurrido en el objeto de texto TMP en formato "00:00"
    void DisplayElapsedTime()
    {
        if (timeText != null)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
            timeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
    }

    void CalculateScore()
    {
        int timePenalty = Mathf.FloorToInt(elapsedTime * 20);
        score -= timePenalty;
        if (score < 0)
        {
            score = 0;
        }

        if (scoreText != null)
        {
            scoreText.text = score.ToString() + "pts";
        }
    }

    void SaveData()
    {
        string scoreAndTime = $"{score}pts - {timeText.text}";

        string[] bestScores = new string[3];
        for (int i = 0; i < 3; i++)
        {
            bestScores[i] = PlayerPrefs.GetString($"BestScore{i}", "0pts - 00:00");
        }

        for (int i = 0; i < 3; i++)
        {
            string storedScoreAndTime = bestScores[i];
            int storedScore = int.Parse(storedScoreAndTime.Split('p')[0]);
            if (score > storedScore)
            {
                string temp = bestScores[i];
                bestScores[i] = scoreAndTime;
                scoreAndTime = temp;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetString($"BestScore{i}", bestScores[i]);
        }

        PlayerPrefs.Save();
    }
}
