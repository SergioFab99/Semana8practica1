using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo4 : MonoBehaviour
{
    [SerializeField]
     private float circleRadius = 2.0f;
    [SerializeField]
    private float moveSpeed = 1.0f;
    [SerializeField]
    private int life = 5;
    private float angle = 0.0f;

    private void Update()
    {
        MoveInCircle();
    }

    private void MoveInCircle()
    {
        // Calcula las coordenadas circulares
        float x = circleRadius * Mathf.Cos(angle);
        float y = circleRadius * Mathf.Sin(angle);

        // Actualiza la posición del enemigo
        transform.position = new Vector3(x, y, 0);

        // Incrementa el ángulo para que el enemigo se mueva en círculos
        angle += moveSpeed * Time.deltaTime;

        // Ajusta el ángulo para asegurarse de que esté en el rango [0, 360)
        if (angle >= 360.0f)
        {
            angle -= 360.0f;
        }
    }
}
