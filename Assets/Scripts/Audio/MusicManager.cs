using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de gestionar la música de fondo en el juego
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance; // Instancia única del MusicManager (patrón Singleton)

    [SerializeField]
    private MusicLibrary MusicLibrary; // Referencia a la biblioteca de música

    [SerializeField]
    private AudioSource musicSource; // Fuente de audio utilizada para reproducir la música

    // Método Awake para asegurar que solo exista un MusicManager en la escena
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye este objeto para evitar duplicados
        }
        else
        {
            Instance = this; // Asigna esta instancia
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cambiar de escena
        }
    }

    // Método para reproducir una pista de música con una transición de fundido cruzado
    public void PlayMusic(string trackName, float fadeDuration = 0.5f)
    {
        // Inicia la corrutina para cambiar la música con efecto de transición
        StartCoroutine(AnimateMusicCrossFade(MusicLibrary.GetClipFromName(trackName), fadeDuration));
    }

    // Corrutina que maneja el efecto de fundido cruzado entre pistas de música
    IEnumerator AnimateMusicCrossFade(AudioClip nextTrack, float fadeDuration = 0.5f)
    {
        float percent = 0;

        // Fase de desvanecimiento de la música actual
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0, percent); // Reduce gradualmente el volumen
            yield return null;
        }

        // Cambia la pista de música y la reproduce
        musicSource.clip = nextTrack;
        musicSource.Play();

        percent = 0;

        // Fase de aumento progresivo del volumen de la nueva pista
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(0, 1f, percent); // Aumenta gradualmente el volumen
            yield return null;
        }
    }
}
