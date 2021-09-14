using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
    CharacterController controller;
    [SerializeField, Range(0, 100)] float Speed = 10;

    // Smooth rotation.
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 velocity;
    Vector3 direction;
    float myS = 0.027f; // Friktionskoefficient för stål mot is enl w
    float myK = 0.014f;

    // Gravity
    bool jump;
    float jumpHeight = 10f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Input:
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Smooth rotation:
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        // Todo:
        // Add some sort of acceleration?
        // Fix so that glide is more "free" i.e. directions doesnt seem to snap to 8-way or mostly 4-way.
        // Fix a jump

    }

    private void FixedUpdate()
    {
        // Basic movement
        if (direction.magnitude >= 0.1f)
        {
            velocity = direction * Speed * Time.fixedDeltaTime;
            controller.Move(velocity);
        }

        // Gravity
        velocity.y += Physics.gravity.y * Time.fixedDeltaTime;
        if (controller.isGrounded) 
            velocity.y = 0;

        // Gliding on ice
        if (direction.magnitude == 0 && velocity.magnitude != 0)
        {
            velocity -= (velocity) * myK; // Slowly glide to 0, fix this..
            if (Mathf.Approximately(velocity.magnitude, 0))
                velocity = Vector3.zero;

            controller.Move(velocity);
        }
    }
}
