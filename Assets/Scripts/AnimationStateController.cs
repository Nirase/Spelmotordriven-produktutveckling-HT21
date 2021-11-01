using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator; 
    float VelocityY = 0;
    float DirectionX = 0;
    public float acceleration = 2f;
    public float deceleration = 2f;
    public float maxRunVelocity = 2.0f;

    int VelocityZHash;
    int DirectionXHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityZHash = Animator.StringToHash("VelocityY");
        DirectionXHash = Animator.StringToHash("DirectionX");
    }

    void Update()
    {
        // Todo:
        // Some way to find direction from mouse

    // Get input
        // bool upPressed = Input.GetKey(KeyCode.W);
        // bool downPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);

    //Acceleration
        // A
        if(leftPressed && VelocityY < maxRunVelocity)
            VelocityY += Time.deltaTime * acceleration;
        
        // D
        if(rightPressed && VelocityY < maxRunVelocity)
            VelocityY += Time.deltaTime * acceleration;

        // Redo for turn left and right
        // up
        // if(upPressed && VelocityZ < maxRunVelocity)
        //     VelocityZ += Time.deltaTime * acceleration;
        
        // // down
        // if(downPressed && VelocityZ > - maxRunVelocity)
        //     VelocityZ -= Time.deltaTime * acceleration;

 

    // Deceleration
        // up
        if(!leftPressed && VelocityY > 0.0f)
            VelocityY -= Time.deltaTime * deceleration;
        
        // down
        if(!rightPressed && VelocityY < 0.0f)
            VelocityY -= Time.deltaTime * deceleration;

        // // Clamp to zero for Z axis
        // if(!upPressed && !downPressed && VelocityZ !=0 && (VelocityZ > 0.0f && VelocityZ < 0.05f))
        //     VelocityZ = 0.0f;

        // // Turning
        // if(!leftPressed && DirectionX < 0.0f)
        //     DirectionX += Time.deltaTime * deceleration;

        // if(!rightPressed && DirectionX > 0.0f)
        //     DirectionX -= Time.deltaTime * deceleration;

        // // clamp to zero for X axis
        // if(!leftPressed && !rightPressed && DirectionX != 0.0f && (DirectionX > -0.05f && DirectionX < 0.05f))
        //     DirectionX = 0.0f;

        // Clamps
        // if(upPressed && VelocityZ > maxRunVelocity)
        //     VelocityZ = maxRunVelocity;
        // if(downPressed && VelocityZ < -maxRunVelocity)
        //     VelocityZ = -maxRunVelocity;

        // if(leftPressed && DirectionX < -maxRunVelocity)
        //     DirectionX = -maxRunVelocity;
        // if(rightPressed && DirectionX > maxRunVelocity)
        //     DirectionX = maxRunVelocity;    

        animator.SetFloat(VelocityZHash, VelocityY);
        animator.SetFloat(DirectionXHash, DirectionX);
    }
}