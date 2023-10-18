using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeMusica : MonoBehaviour
{
    private AudioSource audioSource;
    private bool estaPausado = true;
    private float tiempoDePausa = 0f;
    public GameObject resumeButton;
    public GameObject pauseButton;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Pausa la reproducción al inicio.
        audioSource.Pause();
    }

    private void Update()
    {
        // Comprueba si se ha pausado la canción y ajusta el tiempo de reproducción.
        if (estaPausado)
        {
            tiempoDePausa += Time.deltaTime;
        }
    }

    public void Reproducir()
    {
        if (estaPausado)
        {
            // Inicia la reproducción desde el principio.
            audioSource.Play();
            estaPausado = false;
        }
        else
        {
            // Reanuda la reproducción desde el tiempo de pausa.
            audioSource.UnPause();
        }
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }

    public void Pausar()
    {
        if (audioSource.isPlaying)
        {
            // Pausa la reproducción y registra el tiempo de pausa.
            audioSource.Pause();
            estaPausado = true;
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
        }
    }
}
