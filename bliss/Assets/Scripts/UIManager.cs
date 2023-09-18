using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject loginUI;
    public GameObject registerUI;
    public GameObject forgotUI;

    private enum UIState
    {
        Main,
        Login,
        Register,
        Forgot
    }

    private UIState currentState;

    private void Start()
    {
        ShowMainUI();
    }

    private void ShowMainUI()
    {
        mainUI.SetActive(true);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        forgotUI.SetActive(false);
        currentState = UIState.Main;
    }

    public void ShowLoginUI()
    {
        mainUI.SetActive(false);
        loginUI.SetActive(true);
        registerUI.SetActive(false);
        forgotUI.SetActive(false);
        currentState = UIState.Login;
    }

    public void ShowRegisterUI()
    {
        mainUI.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(true);
        forgotUI.SetActive(false);
        currentState = UIState.Register;
    }

    public void ShowForgotUI()
    {
        mainUI.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        forgotUI.SetActive(true);
        currentState = UIState.Forgot;
    }

    public void BackToMainUI()
    {
        switch (currentState)
        {
            case UIState.Login:
                ShowMainUI();
                break;
            case UIState.Register:
                ShowMainUI();
                break;
            case UIState.Forgot:
                ShowLoginUI();
                break;
        }
    }
}