using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5.0f;
    [SerializeField]
    private int life = 5;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        Move(movement);
    }

    private void Move(Vector2 direction)
    {
        Vector2 newPos = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
    private void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo1"))
        {
            TakeDamage(1);
        }
    }
}