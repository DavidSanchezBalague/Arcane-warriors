using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Transform firePoint; // Punto desde donde salen las balas
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 2f; // Disparo cada 2 segundos
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootInAllDirections();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootInAllDirections()
    {
        Vector2[] directions = {
            Vector2.up, Vector2.down, Vector2.left, Vector2.right,
            new Vector2(1, 1).normalized, new Vector2(-1, 1).normalized,
            new Vector2(1, -1).normalized, new Vector2(-1, -1).normalized
        };

        foreach (Vector2 dir in directions)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = dir * bulletSpeed;
            }
        }
    }
}
