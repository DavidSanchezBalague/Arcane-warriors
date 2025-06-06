using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingLocal : MonoBehaviour
{
    public TMP_Text textoResultado;

    void Start()
    {
        string nombre = PlayerPrefs.GetString("UltimoNombre", "Jugador");
        int puntos = PlayerPrefs.GetInt("UltimaPuntuacion", 0);

        textoResultado.text = nombre + " - " + puntos + " pts";
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
