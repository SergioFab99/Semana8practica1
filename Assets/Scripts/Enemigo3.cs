using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

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
            yield return new WaitForSeconds(2.0f);

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
}