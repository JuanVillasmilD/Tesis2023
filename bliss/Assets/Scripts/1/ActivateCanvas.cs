using UnityEngine;
using UnityEngine.UI;

public class ActivateCanvas : MonoBehaviour
{
    public GameObject emptyObject; // Arrastra el GameObject vacío que deseas mostrar/ocultar aquí desde el inspector.

    public void ShowEmptyObject()
    {
        if (emptyObject != null)
        {
            emptyObject.SetActive(true);
        }
    }

    public void HideEmptyObject()
    {
        if (emptyObject != null)
        {
            emptyObject.SetActive(false);
        }
    }
}
