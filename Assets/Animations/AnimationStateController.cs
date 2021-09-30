using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator; 
    float VelocityZ = 0;
    float VelocityX = 0;
    Rigidbody rb;
    float acceleration = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");

        if(forwardPressed)
        {
            VelocityZ += Time.deltaTime * acceleration;
        }
    }
}
