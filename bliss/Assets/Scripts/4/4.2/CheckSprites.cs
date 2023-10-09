using UnityEngine;

public class CheckSprites : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;
    [SerializeField]
    private GameObject nextLevel;
    [SerializeField]
    private GameObject currentLevel;
    // Define una tolerancia para la comparación
    private float rotationTolerance = 0.01f;

    void Update()
    {
        bool allPicturesCorrect = true;

        foreach (Transform picture in pictures)
        {
            // Compara si la rotación está dentro de la tolerancia
            if (Mathf.Abs(picture.rotation.z) > rotationTolerance)
            {
                allPicturesCorrect = false;
                break;
            }
        }

        if (allPicturesCorrect)
        {
            nextLevel.SetActive(true);
            currentLevel.SetActive(false);
        }
    }
}
