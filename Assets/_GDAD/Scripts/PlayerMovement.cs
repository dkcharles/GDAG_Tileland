using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb;
    Animator animator;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerManager.Instance.health <= 0) animator.SetBool("isDead", true);
    }

    void FixedUpdate()
    {
        int pSpeed = PlayerManager.Instance.speed;
        rb.AddForce(movement * pSpeed);
    }

    void OnMovement(InputValue value)
    {   // Unity Input System function for movement - called from PlayerInput component

        movement = value.Get<Vector2>();

        if (!animator.GetBool("isDead"))
        {
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
        else
        {
            // what happens if player is dead
        }
    }
}
