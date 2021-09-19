using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
    CharacterController controller;
    [SerializeField, Range(0, 100)] float Speed = 15;

    // Smooth rotation.
    float turnSmoothTime = 0.08f;
    float turnSmoothVelocity;

    Vector3 velocity;
    Vector3 direction;
    float myS = 0.027f; // Friktionskoefficient för stål mot is enl wikipedia
    float myK = 0.014f;

    // Gravity
    public float JumpHeight = 5f;
    public float GroundDistance = 0.2f;
    private bool isGrounded = true;
    private bool isJumping = false;
    public LayerMask Ground;
    private Transform groundChecker;

    // Acceleration:
    private float accelerationValue = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        // Input:
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Smooth rotation : Steer according to movement
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Acceleration
         
        }
  

        if (Input.GetKeyDown(KeyCode.Space))
            isJumping = true;

    }

    private void FixedUpdate()
    {
        // Basic movement
        if (direction.magnitude >= 0.1f)
        {
            accelerationValue = Mathf.Lerp(0, 1, 0.9f);
            velocity = direction * Speed * Time.fixedDeltaTime * accelerationValue;
            controller.Move(velocity);
        }

        // Gravity - Jumping works but is bugged...
        velocity.y += Physics.gravity.y * Time.fixedDeltaTime;
        isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (isGrounded) 
            velocity.y = 0;
        
        if (isJumping)
        {
            velocity.y += Mathf.Sqrt(JumpHeight * -2 * Physics.gravity.y);
            isJumping = false;
            //isGrounded = false;
        }

        // Gliding on ice
        if (direction.magnitude == 0 && velocity.magnitude != 0)
        {
            velocity -= (velocity) * myK; // Current bug, direction of glide becomes 4-way if input is not given simultaneously
            if (Mathf.Approximately(velocity.magnitude, 0))
                velocity = Vector3.zero;

            controller.Move(velocity);
        }
    }
}
