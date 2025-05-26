using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    public SpawnerEnemigos spawner;
    public GameObject tiendaCanvas;
    public int enemigosOleada1 = 3;
    public int enemigosOleada2 = 3;
    public GameObject bossPrefab;

    private int enemigosRestantes;
    private int oleadaActual;
    private int totalOleadas = 2;

    private bool esperandoTienda;    // tienda por oleada
    private bool tiendaManual;       // tienda comprada mid‐round
    private bool bossGenerado;

    void Start()
    {
        IniciarOleada();
    }

    // Llamar desde tu botón “Abrir tienda” mid‐round
    public void MostrarTiendaManual()
    {
        tiendaManual = true;
        Time.timeScale = 0;
        tiendaCanvas.SetActive(true);
    }

    // Interno: cuando realmente acabas la oleada
    void MostrarTiendaPorOleada()
    {
        esperandoTienda = true;
        Time.timeScale = 0;
        tiendaCanvas.SetActive(true);
    }

    public void EnemigoGenerado()
    {
        enemigosRestantes++;
    }

    public void EnemigoEliminado()
    {
        if (bossGenerado) return;

        enemigosRestantes--;
        if (enemigosRestantes <= 0 && !esperandoTienda)
            MostrarTiendaPorOleada();
    }

    // Único método de cierre de tienda
    public void TiendaCerrada()
    {
        Time.timeScale = 1;
        tiendaCanvas.SetActive(false);

        // Si era la tienda que abriste tú manualmente, sólo la cierras
        if (tiendaManual)
        {
            tiendaManual = false;
            return;
        }

        // Si era la tienda de fin de oleada, arranca siguiente
        esperandoTienda = false;
        if (oleadaActual < totalOleadas)
            IniciarOleada();
        else
            GenerarBoss();
    }

    void IniciarOleada()
    {
        oleadaActual++;
        enemigosRestantes = 0;
        int n = (oleadaActual == 1) ? enemigosOleada1 : enemigosOleada2;
        spawner.SpawnOleada(n);
        Debug.Log($"Oleada {oleadaActual} con {n} enemigos");
    }

    void GenerarBoss()
    {
        if (bossGenerado || bossPrefab == null) return;
        Instantiate(bossPrefab, Vector3.zero, Quaternion.identity);
        bossGenerado = true;
        Debug.Log("¡Boss generado!");
    }
}
