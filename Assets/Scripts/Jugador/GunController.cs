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
        Vector2 baseDirection = (target.position - pistol.position).normalized;
        float spreadAngle = 15f; // grados de separación entre balas

        if (tripleDisparoActivado)
        {
            DispararEnDireccion(RotateVector(baseDirection, -spreadAngle));
            DispararEnDireccion(baseDirection);
            DispararEnDireccion(RotateVector(baseDirection, spreadAngle));
        }
        else
        {
            DispararEnDireccion(baseDirection);
        }
    }

    void DispararEnDireccion(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, pistol.position, pistol.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        SoundManager.Instance.PlaySound3D("Shoot", transform.position);

        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
    }

    Vector2 RotateVector(Vector2 v, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radians);
        float cos = Mathf.Cos(radians);
        float newX = v.x * cos - v.y * sin;
        float newY = v.x * sin + v.y * cos;
        return new Vector2(newX, newY).normalized;
    }


    private bool tripleDisparoActivado = false;

    public void ActivarTripleDisparo()
    {
        tripleDisparoActivado = true;
    }
}
