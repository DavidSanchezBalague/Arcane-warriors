using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    public GameObject bossPrefab; // Prefab del jefe final
    public SpawnerEnemigos spawner; // Referencia al spawner de enemigos

    private int enemigosRestantes = 0;
    private bool bossGenerado = false;

    void Start()
    {
        // Esperar un pequeño tiempo para asegurarse de que el spawner ya ha generado los enemigos
        Invoke(nameof(ActualizarEnemigos), 0.1f);
    }

    public void EnemigoGenerado()
    {
        enemigosRestantes++;
        Debug.Log("Enemigos actuales: " + enemigosRestantes);
    }

    public void EnemigoEliminado()
    {
        enemigosRestantes--;
        Debug.Log("Enemigo eliminado. Restantes: " + enemigosRestantes);

        if (enemigosRestantes <= 0 && !bossGenerado)
        {
            GenerarBoss();
        }
    }

    void GenerarBoss()
    {
        if (bossPrefab != null)
        {
            Vector3 posicionBoss = new Vector3(0, 0, 0); // Posición central o donde prefieras
            Instantiate(bossPrefab, posicionBoss, Quaternion.identity);
            Debug.Log("¡Boss generado!");
            bossGenerado = true;
        }
    }

    private void ActualizarEnemigos()
    {
        enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemigo").Length;
        Debug.Log("Número de enemigos al inicio: " + enemigosRestantes);
    }
}
