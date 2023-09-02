using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject loginUI;
    public GameObject registerUI;

    private enum UIState
    {
        Main,
        Login,
        Register
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
        currentState = UIState.Main;
    }

    public void ShowLoginUI()
    {
        mainUI.SetActive(false);
        loginUI.SetActive(true);
        registerUI.SetActive(false);
        currentState = UIState.Login;
    }

    public void ShowRegisterUI()
    {
        mainUI.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(true);
        currentState = UIState.Register;
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
        }
    }
}