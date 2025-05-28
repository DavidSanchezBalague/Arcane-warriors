using UnityEngine;

public class AuraArcana : MonoBehaviour
{
    public float dañoPorSegundo = 10f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            EnemyController vida = other.GetComponent<EnemyController>();
            if (vida != null)
            {
                vida.TakeDamage(1);
            }
        }
    }
}
