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
                personajeImage.rectTransform.localScale = new Vector3(6.845691f, 7.329075f, 4.23646f);
                personajeImage.rectTransform.anchoredPosition = new Vector2(0, -110);
                break;
            case 1: // Ninja
                personajeImage.rectTransform.localScale = new Vector3(6.845691f, 7.329075f, 4.23646f);
                personajeImage.rectTransform.anchoredPosition = new Vector2(0, -72);
                break;
            case 2: // Hechicero
                personajeImage.rectTransform.localScale = new Vector3(6.845691f, 7.329075f, 4.23646f);
                personajeImage.rectTransform.anchoredPosition = new Vector2(0, -131);
                break;
        }
    }

    public void SeleccionarPersonaje()
    {
        PlayerPrefs.SetInt("PersonajeElegido", personajeActual);
        LevelManager.Instance.LoadSceneWithImage("Menu Levels", "FastFade", 0); // Ir a menu de niveles
    }
}
