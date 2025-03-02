using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonesNivel : MonoBehaviour
{
    public Button[] botonesNiveles; // Asigna los botones de nivel en el Inspector
    public Sprite spriteDisponible; // GUI_11
    public Sprite spriteBloqueado; // GUI_13
    // Start is called before the first frame update
    void Start()
    {
        // Asegurar que el progreso comienza en 1 solo si no existe aún
        if (!PlayerPrefs.HasKey("NivelDesbloqueado"))
        {
            PlayerPrefs.SetInt("NivelDesbloqueado", 1);
            PlayerPrefs.Save();
        }

        int nivelDesbloqueado = PlayerPrefs.GetInt("NivelDesbloqueado", 1);
        Debug.Log("Nivel desbloqueado guardado: " + nivelDesbloqueado);

        for (int i = 0; i < botonesNiveles.Length; i++)
        {
            if (i + 1 <= nivelDesbloqueado) // Si el nivel está desbloqueado
            {
                botonesNiveles[i].interactable = true;
                botonesNiveles[i].GetComponent<Image>().sprite = spriteDisponible;
                Debug.Log("Botón de nivel " + (i + 1) + " desbloqueado.");
            }
            else // Si el nivel está bloqueado
            {
                botonesNiveles[i].interactable = false;
                botonesNiveles[i].GetComponent<Image>().sprite = spriteBloqueado;
                Debug.Log("Botón de nivel " + (i + 1) + " bloqueado.");
            }
        }
    }
}
