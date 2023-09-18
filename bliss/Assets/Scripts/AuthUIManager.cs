using UnityEngine;
using TMPro;

public class AuthUIManager : MonoBehaviour
{
    public static AuthUIManager instance;
    [Header("References")]
    [SerializeField]
    private GameObject mainUI;
    [SerializeField]
    private GameObject loginUI;
    [SerializeField]
    private GameObject registerUI;

    private void Awake()
    {
        mainUI.SetActive(true);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void ClearUI()
    {
        mainUI.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        FireBaseManager.instance.ClearOutputs();
    }

    public void LoginScreen()
    {
        ClearUI();
        mainUI.SetActive(false);
        loginUI.SetActive(true);
    }

    public void RegisterScreen()
    {
        ClearUI();
        mainUI.SetActive(false);
        registerUI.SetActive(true);
    }
}
