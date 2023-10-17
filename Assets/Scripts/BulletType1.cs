using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType1 : MonoBehaviour
{
    public float bulletSpeed = 5.0f; // Velocidad de la bala grande
    public int damage = 10; // Daño causado por la bala grande

    void Start()
    {
        // Obtener el componente Rigidbody2D de la bala
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Aplicar la velocidad a la bala
        rb.velocity = transform.up * bulletSpeed;
    }

    void Update()
    {
        // Aquí puedes agregar lógica adicional para la bala, si es necesario
    }
}

