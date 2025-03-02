using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 10; // Dao que causa la bala

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

            // Destruir la bala inmediatamente y salir del m�todo
            Destroy(gameObject);
            return; // Nos aseguramos de no continuar despu�s de destruir la bala
        }
    }

    void OnBecameInvisible()
    {
        // Destruir la bala si sale de la pantalla
        Destroy(gameObject);
    }
}
