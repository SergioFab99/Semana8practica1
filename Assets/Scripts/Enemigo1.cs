using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 2.0f;
    [SerializeField] 
    private float leftBound = -5.0f;
    [SerializeField] 
    private float rightBound = 5.0f;

    private int direction = 1; // 1 para moverse a la derecha, -1 para moverse a la izquierda

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        // Si llega al límite derecho, cambia de dirección a la izquierda
        if (transform.position.x >= rightBound)
        {
            direction = -1;
        }

        // Si llega al límite izquierdo, cambia de dirección a la derecha
        if (transform.position.x <= leftBound)
        {
            direction = 1;
        }
    }
}

