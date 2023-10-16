using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // private variables
    [SerializeField] int playerSpeed = 5;
    Vector2 movement;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * playerSpeed);
    }

    void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
