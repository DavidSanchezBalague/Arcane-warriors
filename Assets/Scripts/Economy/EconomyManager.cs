using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance;
    public UIEconomia uiEconomia;

    private int monedas = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistencia entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarMonedas(int cantidad)
    {
        monedas += cantidad;
        Debug.Log("Monedas: " + monedas);
        if (uiEconomia != null)
            uiEconomia.ActualizarMonedas(monedas);
    }

    public bool GastarMonedas(int cantidad)
    {
        if (monedas >= cantidad)
        {
            monedas -= cantidad;
            Debug.Log("Gastaste " + cantidad + ". Te quedan: " + monedas);
            return true;
        }
        else
        {
            Debug.Log("No tienes suficientes monedas.");
            return false;
        }
    }

    public int ObtenerMonedas()
    {
        return monedas;
    }
}
