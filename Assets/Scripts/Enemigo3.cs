using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private GameObject bulletPrefab; // Prefab de la bala
    [SerializeField] private Transform firePoint1; // Primer punto de origen de los disparos (izquierda)
    [SerializeField] private Transform firePoint2; // Segundo punto de origen de los disparos (derecha)

    private Vector3 currentDirection;
    private bool isMoving = false;

    private void Start()
    {
        // Iniciar la rutina para cambiar de dirección cada 5 segundos.
        StartCoroutine(ChangeDirectionPeriodically());
    }

    private void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
    }

    private IEnumerator ChangeDirectionPeriodically()
    {
        while (true)
        {
            // Espera 5 segundos
            yield return new WaitForSeconds(5.0f);

            // Elige una nueva dirección aleatoria
            currentDirection = Random.insideUnitCircle.normalized;

            // Invierte la dirección con cierta probabilidad para cambiar de dirección
            if (Random.value < 0.5f)
            {
                currentDirection = -currentDirection;
            }

            // Comienza a moverse en la nueva dirección
            isMoving = true;

            // Espera 1 segundo antes de detener el movimiento
            yield return new WaitForSeconds(1.0f);

            // Detiene el movimiento
            isMoving = false;
        }
    }

    private void ShootTwoBullets()
    {
        if (bulletPrefab != null && firePoint1 != null && firePoint2 != null)
        {
            // Crear una instancia de la bala en el primer punto de origen (izquierda)
            GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);

            // Configurar la velocidad de la primera bala hacia la izquierda
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.velocity = -transform.right * 5.0f; // Velocidad hacia la izquierda

            // Crear una instancia de la bala en el segundo punto de origen (derecha)
            GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

            // Configurar la velocidad de la segunda bala hacia la derecha
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.velocity = transform.right * 5.0f; // Velocidad hacia la derecha
        }
    }
}
