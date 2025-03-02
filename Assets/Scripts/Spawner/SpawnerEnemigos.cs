using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject[] prefabsEnemigos; // Array de prefabs de enemigos
    public int cantidadInicial = 5; // Cantidad inicial de enemigos
    public float spawnRate = 2f; // Tiempo entre spawns (en segundos)
    public Rect limitesSpawn; // Rectángulo de los límites de spawn
    public int maxEnemigos = 20; // Máximo número de enemigos permitidos

    private int enemigosActuales = 0; // Contador de enemigos generados
    private ControladorEnemigos controladorEnemigos; // Referencia al controlador

    void Start()
    {
        controladorEnemigos = FindObjectOfType<ControladorEnemigos>(); // Buscar el controlador en la escena
        GameObject prefabElegido = prefabsEnemigos[Random.Range(0, prefabsEnemigos.Length)];
        if (prefabsEnemigos == null || prefabsEnemigos.Length == 0)
        {
            Debug.LogError("¡No hay prefabs de enemigos asignados!");
            return;
        }



        Debug.Log("Se han asignado " + prefabsEnemigos.Length + " prefabs de enemigos.");

        for (int i = 0; i < cantidadInicial; i++)
        {
            SpawnEnemigo();
        }

        InvokeRepeating(nameof(SpawnEnemigo), spawnRate, spawnRate);
    }

    void SpawnEnemigo()
    {
        if (enemigosActuales >= maxEnemigos)
        {
            Debug.Log("Se ha alcanzado el límite de enemigos, deteniendo el spawn.");
            CancelInvoke(nameof(SpawnEnemigo));
            return;
        }

        if (prefabsEnemigos == null || prefabsEnemigos.Length == 0)
        {
            Debug.LogError("No hay prefabs de enemigos disponibles. Cancela el spawn.");
            CancelInvoke(nameof(SpawnEnemigo));
            return;
        }

        // Elegir un prefab no nulo
        GameObject prefabElegido = null;
        int intentos = 10; // Evita bucles infinitos en caso de muchos nulls

        while (intentos > 0)
        {
            prefabElegido = prefabsEnemigos[Random.Range(0, prefabsEnemigos.Length)];
            if (prefabElegido != null) break;
            intentos--;
        }

        if (prefabElegido == null)
        {
            Debug.LogError("No se pudo encontrar un prefab válido tras varios intentos.");
            return;
        }

        float x = Random.Range(limitesSpawn.xMin, limitesSpawn.xMax);
        float y = Random.Range(limitesSpawn.yMin, limitesSpawn.yMax);
        Vector3 posicionSpawn = new Vector3(x, y, 0f);

        // Validar antes de instanciar
        if (prefabElegido != null)
        {
            GameObject nuevoEnemigo = Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);
            enemigosActuales++;

            if (controladorEnemigos != null)
            {
                controladorEnemigos.EnemigoGenerado();
            }

            Debug.Log("Enemigo generado (" + prefabElegido.name + ") en posición: " + posicionSpawn);
        }
        else
        {
            Debug.LogError("El prefab elegido es null justo antes de instanciarlo.");
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(limitesSpawn.center, new Vector3(limitesSpawn.width, limitesSpawn.height, 1f));
    }
}
