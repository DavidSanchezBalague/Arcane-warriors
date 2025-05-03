using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SeleccionPersonaje : MonoBehaviour
{
    public Image personajeImage;
    public Sprite[] personajesSprites;
    public Sprite[] fondosSprites;
    public Image fondo;

    private int personajeActual = 0;

    void Start()
    {
        ActualizarVisual();
    }

    public void Siguiente()
    {
        personajeActual = (personajeActual + 1) % personajesSprites.Length;
        ActualizarVisual();
    }

    public void Anterior()
    {
        personajeActual--;
        if (personajeActual < 0)
            personajeActual = personajesSprites.Length - 1;

        ActualizarVisual();
    }

    void ActualizarVisual()
    {
        personajeImage.sprite = personajesSprites[personajeActual];
        fondo.sprite = fondosSprites[personajeActual];

        // Ajustar escala según personaje
        switch (personajeActual)
        {
            case 0: // Gladiador
                personajeImage.rectTransform.localScale = new Vector3(5.42f, 9.38f, 5.42f);
                personajeImage.rectTransform.anchoredPosition = new Vector2(0, -150);
                break;
            case 1: // Ninja
                personajeImage.rectTransform.localScale = new Vector3(5.54f, 7.18f, 5.54f);
                personajeImage.rectTransform.anchoredPosition = new Vector2(0, -128);
                break;
            case 2: // Hechicero
                personajeImage.rectTransform.localScale = new Vector3(6.67f, 8.66f, 6.67f);
                personajeImage.rectTransform.anchoredPosition = new Vector2(0, -101);
                break;
        }
    }

    public void SeleccionarPersonaje()
    {
        PlayerPrefs.SetInt("PersonajeElegido", personajeActual);
        LevelManager.Instance.LoadSceneWithImage("Menu Levels", "CrossFade", 0); // Ir a menu de niveles
    }
}
