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

    [SerializeField]
    private GameObject forgotUI;

    [SerializeField]
    private GameObject emailUI;

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
        forgotUI.SetActive(false);
        emailUI.SetActive(false);
        FireBaseManager.instance.ClearOutputs();
    }

    public void LoginScreen()
    {
        ClearUI();
        loginUI.SetActive(true);
    }

    public void RegisterScreen()
    {
        ClearUI();
        registerUI.SetActive(true);
    }

    public void ForgotScreen()
    {
        ClearUI();
        forgotUI.SetActive(true);
    }

    public void BackToMainScreen()
    {
        ClearUI();
        mainUI.SetActive(true);
    }

    public void EmailScreen()
    {
        ClearUI();
        emailUI.SetActive(true);
    }
}
