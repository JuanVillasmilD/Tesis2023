using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LoadingScreen : MonoBehaviour
{
    public float loadDelay = 1.5f; // Duración en segundos de la pantalla de carga.

    void Start()
    {
        // Inicia una corutina para cargar la siguiente escena después del tiempo especificado.
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        // Espera durante el tiempo especificado.
        yield return new WaitForSeconds(loadDelay);

        SceneManager.LoadScene(2);
    }
}
