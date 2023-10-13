using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public string sceneToLoadOnExit;

    // Función para pausar el juego
    public void PauseGame()
    {
        Time.timeScale = 0f; // Pausa el tiempo
        pauseMenu.SetActive(true);
    }

    // Función para reanudar el juego
    public void ResumeGame()
    {
        Time.timeScale = 1f;
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
