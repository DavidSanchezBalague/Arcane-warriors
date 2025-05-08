using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
           // DontDestroyOnLoad(gameObject); // Persistencia entre escenas
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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Busca una nueva instancia de UIEconomia en la nueva escena
        uiEconomia = FindObjectOfType<UIEconomia>();

        // Actualiza el texto con la cantidad actual
        if (uiEconomia != null)
            uiEconomia.ActualizarMonedas(monedas);
    }

    public void ReiniciarMonedas()
    {
        monedas = 0;
        if (uiEconomia != null)
            uiEconomia.ActualizarMonedas(monedas);
    }


}
