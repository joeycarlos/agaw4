using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private float horizontalMovement;
    private float verticalMovement;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        ReadInput();
        Move(CalculateMoveVector());
    }

    void ReadInput() {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    Vector2 CalculateMoveVector() {
        Vector2 moveVector = new Vector2(horizontalMovement, verticalMovement);
        moveVector.Normalize();
        moveVector *= moveSpeed;
        return moveVector;
    }

    void Move(Vector2 moveVector) {
        rb.MovePosition(new Vector2 (transform.position.x, transform.position.y) + moveVector * Time.deltaTime);
    }
}
