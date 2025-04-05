using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEconomia : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;
    // Start is called before the first frame update
    private void Start()
    {
        ActualizarMonedas(0); // Inicializa en 0
    }

    public void ActualizarMonedas(int cantidad)
    {
        textoMonedas.text = "x " + cantidad.ToString();
    }
}
