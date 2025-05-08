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
            GameObject instancia = Instantiate(personajesPrefabs[personajeElegido], puntoSpawn.position, Quaternion.identity);

            // Buscar el script VidaPersonaje en el personaje instanciado
            VidaPersonaje vida = instancia.GetComponent<VidaPersonaje>();

            // Buscar el script JugadorVida en la escena
            JugadorVida uiVida = FindObjectOfType<JugadorVida>();

            // Asignar la vida al UI si ambos existen
            if (vida != null && uiVida != null)
            {
                uiVida.AsignarVida(vida);
            }
            else
            {
                Debug.LogWarning("No se pudo asignar la vida al UI.");
            }
        }
        else
        {
            Debug.LogWarning("No se ha asignado el prefab del personaje aún.");
        }
    }

}
