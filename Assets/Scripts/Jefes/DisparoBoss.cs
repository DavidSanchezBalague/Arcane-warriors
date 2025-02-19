using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBoss : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab de la bala
    public Transform firePoint;      // Punto de origen de las balas
    public int numberOfBullets = 8;  // N�mero de balas a disparar
    public float bulletSpeed = 5f;   // Velocidad de la bala
    public float fireRate = 2f;      // Tiempo entre disparos

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 1f, fireRate); // Disparar repetidamente
    }

    void Shoot()
    {
        float angleStep = 360f / numberOfBullets; // �ngulo entre cada bala
        float angle = 0f;

        for (int i = 0; i < numberOfBullets; i++)
        {
            // Calcula la direcci�n de la bala
            float bulletDirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

            // Instancia la bala y le da direcci�n
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            angle += angleStep; // Incrementa el �ngulo para la siguiente bala
        }
    }
}
