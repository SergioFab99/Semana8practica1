using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletType1Prefab; // Prefab de la bala grande
    [SerializeField] private GameObject bulletType2Prefab; // Prefab de la bala pequeña

    private Transform firePoint; // Punto de origen de los disparos
    private Vector3 lastPlayerDirection = Vector3.up; // Almacena la última dirección del jugador

    private void Start()
    {
        firePoint = transform.Find("FirePoint"); // Asigna el firepoint en el jugador
    }

    private void Update()
    {
        // Detectar el disparo de la bala grande con la tecla "X"
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot(bulletType1Prefab);
        }

        // Detectar el disparo de la bala pequeña con la tecla "Y"
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Shoot(bulletType2Prefab);
        }

        // Detectar el movimiento del jugador y almacenar la última dirección
        Vector3 playerDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            playerDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerDirection += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerDirection += Vector3.right;
        }

        if (playerDirection != Vector3.zero)
        {
            lastPlayerDirection = playerDirection.normalized;
        }
    }

    private void Shoot(GameObject bulletPrefab)
    {
        // Crear una instancia de la bala en la posición del firepoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Ajustar la rotación de la bala para que dispare en la última dirección del jugador
        bullet.transform.up = lastPlayerDirection;
    }
}
