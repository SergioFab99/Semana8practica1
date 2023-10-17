using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletType1; // Prefab del primer tipo de bala
    [SerializeField] private GameObject bulletType2; // Prefab del segundo tipo de bala
    [SerializeField] private Transform firePoint; // Punto de origen de los disparos

    private void Update()
    {
        // Detectar el primer tipo de disparo con la tecla "X"
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot(bulletType1);
        }

        // Detectar el segundo tipo de disparo con la tecla "Y"
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Shoot(bulletType2);
        }
    }

    private void Shoot(GameObject bulletPrefab)
    {
        // Crear una instancia de la bala en el punto de origen
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // No necesitas ajustar la velocidad de la bala aquí; se maneja en el script de la bala
    }
}

