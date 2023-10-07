using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBombillos : MonoBehaviour
{
    public Sprite spriteBombilloGris;
    public Sprite spriteBombilloBlanco;
    public Sprite spriteBombilloAzul; // Sprite para el bombillo azul.
    public Sprite spriteBombilloAmarillo; // Sprite para el bombillo amarillo.

    public AudioClip sonidoBombillo; // Sonido a reproducir cuando se selecciona un bombillo.

    private SpriteRenderer spriteRenderer;
    private bool seleccionado = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ActualizarSpriteInicial();
    }

    void ActualizarSpriteInicial()
    {
        // Asignar aleatoriamente el sprite del bombillo gris o blanco.
        Sprite spriteInicial = Random.Range(0f, 1f) < 0.5f ? spriteBombilloGris : spriteBombilloBlanco;
        spriteRenderer.sprite = spriteInicial;
    }

    private void OnMouseDown()
    {
        if (!seleccionado)
        {
            CambiarColorYSonido();
        }
    }

    void CambiarColorYSonido()
    {
        seleccionado = true;

        // Cambiar el sprite a azul o amarillo según el color original.
        if (spriteRenderer.sprite == spriteBombilloGris)
        {
            spriteRenderer.sprite = spriteBombilloAzul;
        }
        else
        {
            spriteRenderer.sprite = spriteBombilloAmarillo;
        }

        // Reproducir el sonido del bombillo.
        if (sonidoBombillo != null)
        {
            AudioSource.PlayClipAtPoint(sonidoBombillo, transform.position);
        }
    }
}
