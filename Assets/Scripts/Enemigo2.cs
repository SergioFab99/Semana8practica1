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

    private int direction = 1; // 1 para moverse hacia abajo, -1 para moverse hacia arriba

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * direction * moveSpeed * Time.deltaTime);

        // Si llega al límite superior, cambia de dirección hacia abajo
        if (transform.position.y >= upperBound)
        {
            direction = -1;
        }

        // Si llega al límite inferior, cambia de dirección hacia arriba
        if (transform.position.y <= lowerBound)
        {
            direction = 1;
        }
    }
}

