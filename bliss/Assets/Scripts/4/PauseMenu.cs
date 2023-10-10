using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public string sceneToLoadOnExit;

    private bool isGamePaused = false;
    private float previousTimeScale;

    private void Start()
    {
        // Asegúrate de que el menú de pausa esté desactivado al inicio
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    // Función para pausar o reanudar el juego cuando se presiona un botón
    public void TogglePause()
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // Función para pausar el juego
    public void PauseGame()
    {
        isGamePaused = true;
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f; // Pausa el tiempo
        pauseMenu.SetActive(true);
    }

    // Función para reanudar el juego
    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = previousTimeScale; // Reanuda el tiempo
        pauseMenu.SetActive(false);
    }

    // Función para volver a cargar la escena actual
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Función para salir y cargar una escena específica
    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToLoadOnExit);
    }
}
