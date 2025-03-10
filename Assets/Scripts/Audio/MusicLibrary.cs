using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Estructura serializable que representa una pista de m�sica con su nombre y su clip de audio correspondiente
[System.Serializable]
public struct MusicTrack
{
    public string trackName; // Nombre identificador de la pista de m�sica
    public AudioClip clip;   // Clip de audio asociado a la pista
}

// Clase que act�a como una biblioteca de m�sica, permitiendo obtener pistas de audio por su nombre
public class MusicLibrary : MonoBehaviour
{
    public MusicTrack[] tracks; // Lista de pistas de m�sica disponibles en la biblioteca

    // M�todo que busca y devuelve un clip de m�sica basado en su nombre
    public AudioClip GetClipFromName(string trackName)
    {
        // Recorre todas las pistas de la biblioteca
        foreach (var track in tracks)
        {
            // Si el nombre de la pista coincide con el buscado, devuelve su clip
            if (track.trackName == trackName)
            {
                return track.clip;
            }
        }
        return null; // Retorna null si no se encuentra la pista con el nombre especificado
    }
}
