using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float upperBound = 5.0f;
    [SerializeField]
    private float lowerBound = -5.0f;
    [SerializeField]
    private GameObject bulletPrefab; // Prefab de la bala
    [SerializeField]
    private Transform firePoint; // Punto de origen de los disparos

    private int direction = 1; // 1 para moverse hacia abajo, -1 para moverse hacia arriba

    private float fireRate = 2.0f; // Frecuencia de disparo (cada 2 segundos)
    private float nextFireTime; // Tiempo del próximo disparo

    private void Start()
    {
        nextFireTime = Time.time + fireRate;
    }

    private void Update()
    {
        Move();

        // Disparar balas hacia adelante si es el momento adecuado
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Actualizar el tiempo del próximo disparo
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.up * direction * moveSpeed * Time.deltaTime);

        if (transform.position.y >= upperBound)
        {
            direction = -1;
        }

        if (transform.position.y <= lowerBound)
        {
            direction = 1;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Crear una instancia de la bala en el punto de origen
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Configurar la velocidad de la bala hacia adelante (puede ajustarla según tus necesidades)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-5.0f, 0);
            // Destruir la bala después de 2 segundos
            Destroy(bullet, 2.0f); // 2.0f es el tiempo de retraso en segundos
        }
    }
}