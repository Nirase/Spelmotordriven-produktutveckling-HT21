using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_CharacterController : MonoBehaviour
{
    CharacterController controller;
    private Vector3 velocity;
    private Vector3 inputs;
    private bool grounded;
    private float gravityValue = -9.82f;

    [SerializeField, Range(0, 100)] float Speed = 10;
    [SerializeField, Range(0, 100)] float JumpHeight = 10;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input management
        inputs = Vector3.zero;
        inputs.x = Input.GetAxisRaw("Horizontal");
        inputs.z = Input.GetAxisRaw("Vertical");

        if (inputs != Vector3.zero) 
            transform.forward = inputs;

        // Gravity
        grounded = controller.isGrounded;
        if (grounded && velocity.y < 0)
            velocity.y = 0;
        velocity.y += gravityValue * Time.deltaTime;

        // Jump - Semi working.
        //if (Input.GetButtonDown("Jump") && grounded)
        //{
        //    velocity.y += Mathf.Sqrt(JumpHeight * -2f * gravityValue);
        //}

        // Friction



        // Compute
        controller.Move(motion: inputs * (Time.deltaTime * Speed));
        controller.Move(motion: velocity * Time.deltaTime);
    }

}
