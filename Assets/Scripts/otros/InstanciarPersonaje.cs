using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPersonaje : MonoBehaviour
{
    public GameObject[] personajesPrefabs; // Gladiador, Ninja, Hechicero
    public Transform puntoSpawn;

    void Start()
    {
        int personajeElegido = PlayerPrefs.GetInt("PersonajeElegido", 0);
        if (personajesPrefabs.Length > personajeElegido && personajeElegido >= 0)
        {
            Instantiate(personajesPrefabs[personajeElegido], puntoSpawn.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el prefab del personaje aún.");
        }

    }
}
