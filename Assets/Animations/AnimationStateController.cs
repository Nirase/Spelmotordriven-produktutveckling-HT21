using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator; 
    int velocityHash;
    float deceleration= 0.5f;
    Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // bool forwardPressed = Input.GetKey("W");
        // if (!forwardPressed && velocity > 0.0f)
        // {
        //     velocity -= Time.deltaTime * deceleration;
        // }

        animator.SetFloat(velocityHash, (int)rb.velocity.magnitude);
    }
}
