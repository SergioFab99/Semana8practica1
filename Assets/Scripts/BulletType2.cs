using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType2 : MonoBehaviour
{
    public float bulletSpeed = 10.0f; // Velocidad de la bala pequeña
    public int damage = 5; // Daño causado por la bala pequeña

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
