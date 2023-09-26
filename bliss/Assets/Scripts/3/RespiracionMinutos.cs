using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespiracionMinutos : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;
    public GameObject objeto4;

    public Button boton1;
    public Button boton2;
    public Button boton3;
    public Button boton4;

    public string sceneNameToLoad;
    public Button nextscene;

    private void Start()
    {
        // Configura las funciones de los botones para cambiar de objeto
        boton1.onClick.AddListener(ShowObjeto1);
        boton2.onClick.AddListener(ShowObjeto2);
        boton3.onClick.AddListener(ShowObjeto3);
        boton4.onClick.AddListener(ShowObjeto4);
        nextscene.onClick.AddListener(LoadScene);
    }

    private void ShowObjeto1()
    {
        objeto1.SetActive(true);
        objeto2.SetActive(false);
        objeto3.SetActive(false);
        objeto4.SetActive(false);
    }

    private void ShowObjeto2()
    {
        objeto1.SetActive(false);
        objeto2.SetActive(true);
        objeto3.SetActive(false);
        objeto4.SetActive(false);
    }

    private void ShowObjeto3()
    {
        objeto1.SetActive(false);
        objeto2.SetActive(false);
        objeto3.SetActive(true);
        objeto4.SetActive(false);
    }

    private void ShowObjeto4()
    {
        objeto1.SetActive(false);
        objeto2.SetActive(false);
        objeto3.SetActive(false);
        objeto4.SetActive(true);
    }

    private void LoadScene()
    {
        // Carga la escena configurada en el Inspector
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
