using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    private AudioSource audioSource; // Referencia al componente AudioSource que reproduce el audio

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Inicia la reproducción del audio al comenzar la escena
        audioSource.Play();
    }

    public void PauseAudio()
    {
        // Pausa la reproducción del audio
        audioSource.Pause();
    }

    public void ResumeAudio()
    {
        // Reanuda la reproducción del audio
        audioSource.UnPause();
    }
}
