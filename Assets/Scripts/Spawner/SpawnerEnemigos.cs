using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject[] prefabsEnemigos;
    public Rect limitesSpawn;
    private ControladorEnemigos controladorEnemigos;

    void Start()
    {
        controladorEnemigos = FindObjectOfType<ControladorEnemigos>();
    }

    public void SpawnOleada(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            SpawnEnemigo();
        }
    }

    void SpawnEnemigo()
    {
        GameObject prefabElegido = prefabsEnemigos[Random.Range(0, prefabsEnemigos.Length)];
        float x = Random.Range(limitesSpawn.xMin, limitesSpawn.xMax);
        float y = Random.Range(limitesSpawn.yMin, limitesSpawn.yMax);
        Vector3 posicion = new Vector3(x, y, 0f);

        GameObject enemigo = Instantiate(prefabElegido, posicion, Quaternion.identity);

        // 🔥 APLICAR STATS DEL NIVEL
        EnemyStats stats = LevelManager.Instance.GetStatsActuales();

        EnemyController controller = enemigo.GetComponent<EnemyController>();
        if (controller != null)
        {
            controller.maxHealth = stats.maxHealth;

            // Reiniciar la vida actual por si acaso
            // (por ejemplo, si reusas enemigos de un pool en el futuro)
            var campoPrivado = controller.GetType().GetField("currentHealth", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (campoPrivado != null)
            {
                campoPrivado.SetValue(controller, stats.maxHealth);
            }
            // Si usas damage también:
            // controller.damage = stats.damage;
        }

        EnemigoMovimiento mover = enemigo.GetComponent<EnemigoMovimiento>();
        if (mover != null)
        {
            mover.velocidad = stats.velocidad;
        }

        if (controladorEnemigos != null)
            controladorEnemigos.EnemigoGenerado();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(limitesSpawn.center, new Vector3(limitesSpawn.width, limitesSpawn.height, 1f));
    }
}