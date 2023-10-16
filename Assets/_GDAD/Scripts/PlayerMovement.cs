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
    Animator animator;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * playerSpeed);
    }
    
    void OnMovement(InputValue value)
    {   // Unity Input System function for movement - called from PlayerInput component

        movement = value.Get<Vector2>();

        // if the player is moving (movement value is not zero), set the animator parameters
        if (movement != Vector2.zero)   
        { 
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
