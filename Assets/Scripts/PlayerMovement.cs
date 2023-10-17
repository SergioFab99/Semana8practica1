using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5.0f;

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
}
