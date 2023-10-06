using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiarEscena : MonoBehaviour
{
    public string nombreEscena = "";

    private void Start()
    {
        Button boton = GetComponent<Button>();
        boton.onClick.AddListener(CargarEscena);
    }

    private void CargarEscena()
    {
        // Encuentra el objeto TimeManager en la escena actual
        TimeManager timeManager = FindObjectOfType<TimeManager>();

        if (timeManager != null)
        {
            // Establece la velocidad de tiempo a 1 utilizando el TimeManager
            timeManager.SetTimeScale(1);
        }

        // Carga la nueva escena
        SceneManager.LoadScene(nombreEscena);
    }
}
