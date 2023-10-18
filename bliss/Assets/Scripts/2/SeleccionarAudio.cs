using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionarAudio : MonoBehaviour
{
    public GameObject homePage;
    public GameObject audioOption; // Arrastra el GameObject vacío que deseas mostrar/ocultar aquí desde el inspector.
    public string nombreEscena = "";

    public void ShowEmptyObject()
    {
        if (audioOption != null)
        {
            audioOption.SetActive(true);
            homePage.SetActive(false);
        }
    }

    public void HideEmptyObject()
    {
        if (audioOption != null)
        {
            audioOption.SetActive(false);
            homePage.SetActive(true);
        }
    }

    public void CargarAudio()
    {
        // Carga la nueva escena
        SceneManager.LoadScene(nombreEscena);
    }
}
