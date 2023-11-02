using UnityEngine;
using TMPro;

public class PuntajesSM : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI puntajesText;

    private void Start()
    {
        string records = PlayerPrefs.GetString("BestRecordsSM", "");
        string[] recordArray = records.Split(',');

        if (recordArray.Length > 0)
        {
            System.Array.Sort(recordArray);

            string top3RecordsText = "";

            for (int i = 0; i < Mathf.Min(recordArray.Length, 3); i++)
            {
                string[] recordParts = recordArray[i].Split('_');
                int score = int.Parse(recordParts[0]);
                float time = float.Parse(recordParts[1]);

                int minutes = Mathf.FloorToInt(time / 60);
                int seconds = Mathf.FloorToInt(time % 60);
                string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

                top3RecordsText += "Puntaje: " + score + " - Tiempo: " + timeString + "\n";
            }

            puntajesText.text = top3RecordsText;
        }
        else
        {
            puntajesText.text = "No hay puntajes registrados.";
        }
    }
}
