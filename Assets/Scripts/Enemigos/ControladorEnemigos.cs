using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    public GameObject bossPrefab;
    public SpawnerEnemigos spawner;
    public GameObject tiendaCanvas; // Asigna el canvas de la tienda en el inspector

    private int enemigosRestantes = 0;
    private int oleadaActual = 0;
    private int totalOleadas = 2;
    private bool esperandoTienda = false;
    private bool bossGenerado = false;
    public int enemigosOleada1 = 3;
    public int enemigosOleada2 = 3;

    void Start()
    {
        IniciarOleada();
    }

    public void EnemigoGenerado()
    {
        enemigosRestantes++;
    }

    public void EnemigoEliminado()
    {
        enemigosRestantes--;

        // Si el boss ya fue generado, no mostrar tienda
        if (bossGenerado)
        {
            return;
        }

        if (enemigosRestantes <= 0 && !esperandoTienda)
        {
            esperandoTienda = true;
            MostrarTienda();
        }
    }

    void MostrarTienda()
    {
        Time.timeScale = 0;
        tiendaCanvas.SetActive(true);
    }

    public void TiendaCerrada() // Llamado desde ShopUIManager cuando se cierra la tienda
    {
        Time.timeScale = 1;
        tiendaCanvas.SetActive(false);

        esperandoTienda = false;

        if (oleadaActual < totalOleadas)
        {
            IniciarOleada();
        }
        else
        {
            GenerarBoss();
        }
    }

    void IniciarOleada()
    {
        oleadaActual++;
        enemigosRestantes = 0;

        int cantidadEnemigos = 0;

        if (oleadaActual == 1)
        {
            cantidadEnemigos = enemigosOleada1;
        }
        else if (oleadaActual == 2)
        {
            cantidadEnemigos = enemigosOleada2;
        }

        spawner.SpawnOleada(cantidadEnemigos);
        Debug.Log("Oleada " + oleadaActual + " iniciada con " + cantidadEnemigos + " enemigos.");
    }

    void GenerarBoss()
    {
        if (bossGenerado || bossPrefab == null) return;

        Instantiate(bossPrefab, Vector3.zero, Quaternion.identity);
        bossGenerado = true;
        Debug.Log("¡Boss generado!");
    }
}