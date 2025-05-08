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

        Instantiate(prefabElegido, posicion, Quaternion.identity);

        if (controladorEnemigos != null)
            controladorEnemigos.EnemigoGenerado();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(limitesSpawn.center, new Vector3(limitesSpawn.width, limitesSpawn.height, 1f));
    }
}