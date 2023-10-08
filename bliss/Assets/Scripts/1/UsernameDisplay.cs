using UnityEngine;
using TMPro;

public class UsernameDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text usernameText;

    private void Start()
    {
        // Obtener el nombre de usuario del FireBaseManager
        string username = FireBaseManager.instance.GetUsername();

        // Configurar el texto del cuadro de texto
        usernameText.text = "¡Hola, " + username + "!";
    }
}
