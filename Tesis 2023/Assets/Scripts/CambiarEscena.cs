using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene(nombreEscena);
    }
}