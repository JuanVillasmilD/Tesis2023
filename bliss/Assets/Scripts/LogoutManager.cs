using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoutManager : MonoBehaviour
{
    public void OnLogoutButtonClick()
    {
        if (FireBaseManager.instance != null)
        {
            FireBaseManager.instance.SignOut(); // Llama al método de FireBaseManager
        }
        else
        {
            Debug.LogWarning("FireBaseManager instance is null.");
        }
    }
}
