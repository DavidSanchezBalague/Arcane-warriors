using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreManager : MonoBehaviour
{
    public InputField nombreInput;
    public Text puntuacionText;

    private int puntuacionFinal;

    void Start()
    {
        puntuacionFinal = PlayerPrefs.GetInt("PuntuacionFinal", 0); // la guardas antes de cambiar de escena
        puntuacionText.text = "Tu puntuación: " + puntuacionFinal.ToString();
    }

    public void GuardarPuntuacion()
    {
        string nombre = nombreInput.text;
        if (string.IsNullOrEmpty(nombre)) return;

        PlayerPrefs.SetString("UltimoNombre", nombre);
        PlayerPrefs.SetInt("UltimaPuntuacion", puntuacionFinal);
        PlayerPrefs.Save();

        Debug.Log("Guardado: " + nombre + " - " + puntuacionFinal);
    }
}
