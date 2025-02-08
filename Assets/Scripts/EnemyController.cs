using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;
    public int pointsForKilling = 10;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ScoreManager.Instance.AddPoints(pointsForKilling);
        SoundManager.Instance.PlaySound3D("hurt", transform.position);
        Destroy(gameObject);
    }
}
