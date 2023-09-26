using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingControl : MonoBehaviour
{
    private Animator[] animators;
    private bool isPaused = false;

    void Start()
    {
        // Obtén los controladores de animación de tus objetos
        animators = GetComponentsInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Cambia "Space" al botón que desees
        {
            isPaused = !isPaused; // Cambia el estado de pausa

            // Activa o desactiva las animaciones según el estado de pausa
            foreach (Animator animator in animators)
            {
                if (isPaused)
                {
                    animator.speed = 0f; // Pausa la animación
                }
                else
                {
                    animator.speed = 1f; // Reanuda la animación
                }
            }
        }
    }
}
