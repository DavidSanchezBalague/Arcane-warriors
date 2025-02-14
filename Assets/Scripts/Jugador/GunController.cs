using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform player;
    public Transform pistol;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    void Update()
    {
        Transform closestEnemy = FindClosestEnemy();

        if (closestEnemy != null)
        {
            PointGunAtEnemy(closestEnemy);

            if (Time.time >= nextFireTime)
            {
                Shoot(closestEnemy);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    Transform FindClosestEnemy()
    {
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");

        foreach (GameObject enemy in enemies)
        {
            Transform enemyTransform = enemy.transform;
            float distance = Vector2.Distance(player.position, enemyTransform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemyTransform;
            }
        }

        return closest;
    }

    void PointGunAtEnemy(Transform enemy)
    {
        Vector2 direction = enemy.position - pistol.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        pistol.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, pistol.position, pistol.rotation);

        SoundManager.Instance.PlaySound3D("Shoot", transform.position);

        Vector2 direction = (target.position - pistol.position).normalized;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
    }
}
