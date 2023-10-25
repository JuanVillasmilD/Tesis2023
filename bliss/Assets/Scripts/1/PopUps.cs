using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{
    public Image imageToActivate;
    public GameObject emptyObject;
    public Image secondImageToActivate;
    public Image fondoToActivate;
    public Image secondfondoToActivate;

    private void Start()
    {
        // Desactiva la imagen y el emptyObject al inicio
        imageToActivate.gameObject.SetActive(false);
        emptyObject.SetActive(false);
        secondImageToActivate.gameObject.SetActive(false);
        fondoToActivate.gameObject.SetActive(false);
        secondfondoToActivate.gameObject.SetActive(false);
    }

    public void ActivateImageAndEmpty()
    {
        StartCoroutine(ActivateImageAndEmptyCoroutine());
    }

    public void ActivateSecondImageAndDeactivateAll()
    {
        StartCoroutine(ActivateSecondImageAndDeactivateAllCoroutine());
    }

    private IEnumerator ActivateImageAndEmptyCoroutine()
    {
        // Activa la imagen
        fondoToActivate.gameObject.SetActive(true);
        imageToActivate.gameObject.SetActive(true);

        // Espera 0.25 segundos
        yield return new WaitForSeconds(0.25f);

        // Desactiva la imagen
        imageToActivate.gameObject.SetActive(false);
        fondoToActivate.gameObject.SetActive(false);

        // Activa el emptyObject
        emptyObject.SetActive(true);
    }

    private IEnumerator ActivateSecondImageAndDeactivateAllCoroutine()
    {
        // Desactiva el emptyObject
        emptyObject.SetActive(false);

        // Activa la segunda imagen
        secondImageToActivate.gameObject.SetActive(true);
        secondfondoToActivate.gameObject.SetActive(true);

        // Espera 0.25 segundos
        yield return new WaitForSeconds(0.25f);

        // Desactiva la segunda imagen
        secondImageToActivate.gameObject.SetActive(false);
        secondfondoToActivate.gameObject.SetActive(false);

    }
}
