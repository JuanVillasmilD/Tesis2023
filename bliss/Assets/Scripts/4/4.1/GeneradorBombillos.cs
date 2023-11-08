using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBombillos : MonoBehaviour
{
    public Sprite spriteBombilloGris;
    public Sprite spriteBombilloBlanco;
    public Sprite spriteBombilloAzul;
    public Sprite spriteBombilloAmarillo;
    public AudioClip sonidoBombillo;
    private BubblesManager deteccionSonido;

    private SpriteRenderer spriteRenderer;

    private bool seleccionado = false;
    public GameObject objetoDeControl; // Asigna el GameObject desde el Inspector.

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ActualizarSpriteInicial();
        deteccionSonido = FindObjectOfType<BubblesManager>();
    }

    void ActualizarSpriteInicial()
    {
        Sprite spriteInicial =
            Random.Range(0f, 1f) < 0.5f ? spriteBombilloGris : spriteBombilloBlanco;
        spriteRenderer.sprite = spriteInicial;
    }

    private void OnMouseDown()
    {
        if (!seleccionado && !objetoDeControl.activeSelf)
        {
            CambiarColorYSonido();
        }
    }

    void CambiarColorYSonido()
    {
        seleccionado = true;

        if (spriteRenderer.sprite == spriteBombilloGris)
        {
            spriteRenderer.sprite = spriteBombilloAzul;
        }
        else
        {
            spriteRenderer.sprite = spriteBombilloAmarillo;
        }

        if (sonidoBombillo != null)
        {
            AudioSource.PlayClipAtPoint(sonidoBombillo, transform.position);
            deteccionSonido.DetectarSonido();
        }
    }
}
