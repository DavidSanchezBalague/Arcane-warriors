using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Estructura serializable que representa un efecto de sonido con un identificador de grupo y una lista de clips de audio
[System.Serializable]
public struct SoundEffect
{
    public string groupID;  // Identificador del grupo de sonidos
    public AudioClip[] clips;  // Array de clips de sonido asociados a este grupo
}

// Clase que actúa como una biblioteca de sonidos, permitiendo acceder a efectos de sonido por su nombre
public class SoundLibrary : MonoBehaviour
{
    public SoundEffect[] soundEffects;  // Lista de efectos de sonido disponibles en la biblioteca

    // Método que busca y devuelve un clip de sonido aleatorio basado en el nombre del grupo
    public AudioClip GetClipFromName(string name)
    {
        // Recorre todos los efectos de sonido en la biblioteca
        foreach (var soundEffect in soundEffects)
        {
            // Si el identificador del grupo coincide con el nombre buscado
            if (soundEffect.groupID == name)
            {
                // Devuelve un clip aleatorio del grupo
                return soundEffect.clips[Random.Range(0, soundEffect.clips.Length)];
            }
        }
        return null;  // Retorna null si no se encuentra un grupo con el nombre especificado
    }
}
