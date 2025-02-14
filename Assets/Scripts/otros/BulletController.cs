using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 10; // Daño que causa la bala

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si la bala colisiona con un enemigo
        if (collision.CompareTag("Enemigo"))
        {
            // Obtener el script del enemigo
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Restar vida al enemigo
            }

            // Destruir la bala inmediatamente y salir del método
            Destroy(gameObject);
            return; // Nos aseguramos de no continuar después de destruir la bala
        }
    }

    void OnBecameInvisible()
    {
        // Destruir la bala si sale de la pantalla
        Destroy(gameObject);
    }
}
