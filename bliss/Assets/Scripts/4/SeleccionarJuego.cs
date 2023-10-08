using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionarJuego : MonoBehaviour
{
    public GameObject homePage;
    public GameObject gameOption; // Arrastra el GameObject vacío que deseas mostrar/ocultar aquí desde el inspector.
    public string nombreEscena = "";

    public void ShowEmptyObject()
    {
        if (gameOption != null)
        {
            gameOption.SetActive(true);
            homePage.SetActive(false);
        }
    }

    public void HideEmptyObject()
    {
        if (gameOption != null)
        {
            gameOption.SetActive(false);
            homePage.SetActive(true);
        }
    }

    public void CargarJuego()
    {
        // Carga la nueva escena
        SceneManager.LoadScene(nombreEscena);
    }
}
