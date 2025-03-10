using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de gestionar la m�sica de fondo en el juego
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance; // Instancia �nica del MusicManager (patr�n Singleton)

    [SerializeField]
    private MusicLibrary MusicLibrary; // Referencia a la biblioteca de m�sica

    [SerializeField]
    private AudioSource musicSource; // Fuente de audio utilizada para reproducir la m�sica

    // M�todo Awake para asegurar que solo exista un MusicManager en la escena
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

    // M�todo para reproducir una pista de m�sica con una transici�n de fundido cruzado
    public void PlayMusic(string trackName, float fadeDuration = 0.5f)
    {
        // Inicia la corrutina para cambiar la m�sica con efecto de transici�n
        StartCoroutine(AnimateMusicCrossFade(MusicLibrary.GetClipFromName(trackName), fadeDuration));
    }

    // Corrutina que maneja el efecto de fundido cruzado entre pistas de m�sica
    IEnumerator AnimateMusicCrossFade(AudioClip nextTrack, float fadeDuration = 0.5f)
    {
        float percent = 0;

        // Fase de desvanecimiento de la m�sica actual
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0, percent); // Reduce gradualmente el volumen
            yield return null;
        }

        // Cambia la pista de m�sica y la reproduce
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
