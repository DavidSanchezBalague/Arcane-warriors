using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;
    public int pointsForKilling = 10;
    private SpriteRenderer spriteRenderer;
    private ControladorEnemigos controlador; // Referencia al ControladorEnemigos

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
        spriteRenderer.enabled = false; // Desactiva el sprite
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = true; // Reactiva el sprite
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

        Destroy(gameObject);
    }

    public int points = 10; // Puntos por matar al enemigo

    private void OnDestroy()
    {
        if (PuntosInGame.instance != null)
        {
            PuntosInGame.instance.AddScore(points);
        }
    }
}
