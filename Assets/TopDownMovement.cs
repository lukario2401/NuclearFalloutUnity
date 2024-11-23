using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Movement speed
    private Rigidbody2D rb;                        // Reference to Rigidbody2D
    private Animator animator;                     // Reference to Animator
    private Vector2 movement;                      // Stores movement input

    void Start()
    {
        // Get components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Ensure required components are available
        if (rb == null)
            Debug.LogError("Rigidbody2D is missing from the player object.");
        if (animator == null)
            Debug.LogError("Animator is missing from the player object.");
    }

    void Update()
    {
        // Get player input
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        // Update animator parameters
        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);
        animator.SetBool("IsWalking", movement != Vector2.zero); // Check if the player is moving

        // Save last movement direction when the player is moving
        if (movement != Vector2.zero) // Only update "last input" when there's actual movement
        {
            animator.SetFloat("LastInputX", movement.x);
            animator.SetFloat("LastInputY", movement.y);
        }
    }

    void FixedUpdate()
    {
        // Apply movement to Rigidbody2D
        rb.linearVelocity = movement.normalized * moveSpeed; // Normalize to maintain consistent speed in all directions
    }
}
