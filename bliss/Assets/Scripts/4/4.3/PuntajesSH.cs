using UnityEngine;
using TMPro;

public class PuntajesSH : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private void Start()
    {
        DisplayHighScores();
    }

    void DisplayHighScores()
    {
        string highScoreTextContent = "";
        for (int i = 0; i < 3; i++)
        {
            string scoreAndTime = PlayerPrefs.GetString($"BestScoreSH{i}", "0pts - 00:00");
            highScoreTextContent += scoreAndTime;
            
            if (i < 2)
            {
                highScoreTextContent += "\n\n\n"; // Add two blank lines between records
            }
        }

        if (highScoreText != null)
        {
            highScoreText.text = highScoreTextContent;
        }
    }
}
