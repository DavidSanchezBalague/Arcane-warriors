using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingLocal : MonoBehaviour
{
    public TMP_Text textoRanking;

    void Start()
    {
        string nombre = PlayerPrefs.GetString("UltimoNombre", "Jugador");
        int puntos = PlayerPrefs.GetInt("UltimaPuntuacion", 0);
        textoRanking.text = "Última puntuación: " + nombre + " - " + puntos + " pts";
    }
}
