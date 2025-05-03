using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPersonajeSeleccionado : MonoBehaviour
{
    void Start()
    {
        int personaje = PlayerPrefs.GetInt("PersonajeElegido", -1);

        switch (personaje)
        {
            case 0:
                Debug.Log("Personaje seleccionado: Gladiador");
                break;
            case 1:
                Debug.Log("Personaje seleccionado: Ninja");
                break;
            case 2:
                Debug.Log("Personaje seleccionado: Hechicero");
                break;
            default:
                Debug.LogWarning("Ningún personaje seleccionado o valor inválido.");
                break;
        }
    }
}
