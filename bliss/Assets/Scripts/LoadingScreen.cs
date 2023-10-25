using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public float loadDelay = 2f; // Duración en segundos de la pantalla de carga.
    public string sceneToLoad = "SceneName"; // Nombre de la escena que se cargará.

    void Start()
    {
        // Inicia una corutina para cargar la siguiente escena después del tiempo especificado.
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        // Espera durante el tiempo especificado.
        yield return new WaitForSeconds(loadDelay);

        // Carga la escena especificada en sceneToLoad.
        SceneManager.LoadScene(sceneToLoad);
    }
}
