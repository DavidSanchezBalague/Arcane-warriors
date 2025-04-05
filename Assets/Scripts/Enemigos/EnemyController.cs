using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;
    public int pointsForKilling = 10;
    public GameObject monedaPrefab;
    private SpriteRenderer spriteRenderer;
    private ControladorEnemigos controlador; // Referencia al ControladorEnemigos

    public bool isBoss = false; // Marcar si este enemigo es el boss
    public GameObject victoryPanel; // Solo el panel de victoria, NO todo el Canvas

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        controlador = FindObjectOfType<ControladorEnemigos>(); // Buscar el controlador en la escena
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(FlashSprite());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator FlashSprite()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = true;
    }

    void Die()
    {
        ScoreManager.Instance.AddPoints(pointsForKilling);
        SoundManager.Instance.PlaySound3D("hurt", transform.position);

        // Notificar al controlador que este enemigo murió
        if (controlador != null)
        {
            controlador.EnemigoEliminado();
        }

        if (monedaPrefab != null)
        {
            Instantiate(monedaPrefab, transform.position, Quaternion.identity);
        }

        // Si este enemigo es el boss, activar solo el panel de victoria
        if (isBoss)
        {
           
            Debug.Log("¡El jugador ha muerto!");
            // Aquí puedes implementar más lógica, como reiniciar el nivel
            FindAnyObjectByType<VictoryScreen>().MostrarVictoria();
        }

        Destroy(gameObject);
    }

    public int points = 10;

    private void OnDestroy()
    {
        if (PuntosInGame.instance != null)
        {
            PuntosInGame.instance.AddScore(points);
        }
    }
}
