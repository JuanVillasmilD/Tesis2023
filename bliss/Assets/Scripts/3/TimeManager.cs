using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            // Si ya existe una instancia de TimeManager, destruye este objeto
            Destroy(gameObject);
            return;
        }

        // Marca este objeto para que no se destruya al cargar una nueva escena
        DontDestroyOnLoad(gameObject);

        instance = this;
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
