using UnityEngine;
using UnityEngine.UI;

public class RespiracionMinutos : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    public Button button1;
    public Button button2;
    public Button button3;

    private void Start()
    {
        // Configura las funciones de los botones para cambiar de objeto
        button1.onClick.AddListener(ShowObject1);
        button2.onClick.AddListener(ShowObject2);
        button3.onClick.AddListener(ShowObject3);
    }

    private void ShowObject1()
    {
        object1.SetActive(true);
        object2.SetActive(false);
        object3.SetActive(false);
    }

    private void ShowObject2()
    {
        object1.SetActive(false);
        object2.SetActive(true);
        object3.SetActive(false);
    }

    private void ShowObject3()
    {
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(true);
    }
}
