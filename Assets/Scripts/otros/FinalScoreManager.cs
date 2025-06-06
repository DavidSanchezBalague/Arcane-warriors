using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScoreManager : MonoBehaviour
{
    public TMP_Text textoPuntuacion;
    public TMP_InputField inputNombre;

    private int puntuacionFinal;

    void Start()
    {
        if (!PlayerPrefs.HasKey("PuntuacionFinal"))
        {
            Debug.LogWarning("NO SE ENCONTRÓ LA CLAVE 'PuntuacionFinal'");
        }

        puntuacionFinal = PlayerPrefs.GetInt("PuntuacionFinal", 0);
        Debug.Log("Valor recibido: " + puntuacionFinal);

        textoPuntuacion.text = "Puntuación: " + puntuacionFinal.ToString();
    }

    public void GuardarPuntuacion()
    {
        string nombre = inputNombre.text;

        if (string.IsNullOrEmpty(nombre))
        {
            Debug.Log("Introduce un nombre válido");
            return;
        }

        PlayerPrefs.SetString("UltimoNombre", nombre);
        PlayerPrefs.SetInt("UltimaPuntuacion", puntuacionFinal);
        PlayerPrefs.Save();

        // Ir a la siguiente escena: RankingLocal
        SceneManager.LoadScene("RankingLocal");
    }
}
