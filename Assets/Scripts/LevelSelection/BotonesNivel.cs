using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesNivel : MonoBehaviour
{
    public Button[] botonesNiveles; // Asigna los botones de nivel en el Inspector
    public Sprite spriteDisponible; // GUI_11
    public Sprite spriteBloqueado; // GUI_13
    // Start is called before the first frame update
    void Start()
    {
        int nivelDesbloqueado = PlayerPrefs.GetInt("NivelDesbloqueado", 1);

        for (int i = 0; i < botonesNiveles.Length; i++)
        {
            if (i + 1 <= nivelDesbloqueado)
            {
                // Nivel desbloqueado: activar botón y asignar imagen disponible
                botonesNiveles[i].interactable = true;
                botonesNiveles[i].GetComponent<Image>().sprite = spriteDisponible;
            }
            else
            {
                // Nivel bloqueado: desactivar botón y asignar imagen bloqueada
                botonesNiveles[i].interactable = false;
                botonesNiveles[i].GetComponent<Image>().sprite = spriteBloqueado;
            }
        }
    }
}
