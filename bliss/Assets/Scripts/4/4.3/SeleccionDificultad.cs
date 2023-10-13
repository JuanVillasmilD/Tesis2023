using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionDificultad : MonoBehaviour
{
    public string juegoEscena = "";

    public void CargarDificultad()
    {
        // Carga la nueva escena
        SceneManager.LoadScene(juegoEscena);
    }
}
