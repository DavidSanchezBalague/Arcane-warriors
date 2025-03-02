using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Administrador de sonidos para un juego 2D, utilizando el patrón Singleton
public class SoundManager : MonoBehaviour
{
    // Instancia única del SoundManager (Singleton)
    public static SoundManager Instance;

    // Biblioteca de sonidos donde se almacenan los efectos de sonido
    [SerializeField]
    private SoundLibrary sfxLibrary;

    // Fuente de audio utilizada para reproducir sonidos en 2D
    [SerializeField]
    private AudioSource sfx2DSource;

    // Método Awake: Asegura que solo haya un SoundManager en la escena
    private void Awake()
    {
        // Si ya existe una instancia, destruye este objeto para evitar duplicados
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            // Asigna esta instancia y evita que se destruya al cambiar de escena
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Método para reproducir un sonido en una posición específica (aunque el juego sea 2D, puede usarse para efectos posicionales)
    public void PlaySound3D(AudioClip clip, Vector3 pos)
    {
        if (clip != null)
        {
            // Reproduce el sonido en la posición dada (aunque en un juego 2D esto no es tan común)
            AudioSource.PlayClipAtPoint(clip, pos);
        }
    }

    // Sobrecarga del método para reproducir un sonido 3D basado en el nombre del sonido
    public void PlaySound3D(string soundName, Vector3 pos)
    {
        // Obtiene el clip de la biblioteca y lo reproduce en la posición dada
        PlaySound3D(sfxLibrary.GetClipFromName(soundName), pos);
    }

    // Método para reproducir sonidos en 2D (lo más común en juegos 2D)
    public void PlaySound2D(string soundName)
    {
        // Busca el sonido en la biblioteca y lo reproduce con la fuente de audio 2D
        sfx2DSource.PlayOneShot(sfxLibrary.GetClipFromName(soundName));
    }
}
