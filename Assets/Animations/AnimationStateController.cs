using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator; 
    float VelocityZ = 0;
    float VelocityX = 0;
    public float acceleration = 2f;
    public float deceleration = 2f;
    public float maxRunVelocity = 2.0f;

    int VelocityZHash;
    int VelocityXHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityZHash = Animator.StringToHash("VelocityZ");
        VelocityXHash = Animator.StringToHash("VelocityX");
    }

    void Update()
    {
    // Get input
        bool upPressed = Input.GetKey(KeyCode.W);
        bool downPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);

    //Acceleration
        // up
        if(upPressed && VelocityZ < maxRunVelocity)
            VelocityZ += Time.deltaTime * acceleration;
        
        // down
        if(downPressed && VelocityZ > - maxRunVelocity)
            VelocityZ -= Time.deltaTime * acceleration;

        // Left
        if(leftPressed && VelocityX > -maxRunVelocity)
            VelocityX -= Time.deltaTime * acceleration;
        
        // Right
        if(rightPressed && VelocityX < maxRunVelocity)
            VelocityX += Time.deltaTime * acceleration;

    // Deceleration
        // up
        if(!upPressed && VelocityZ > 0.0f)
            VelocityZ -= Time.deltaTime * deceleration;
        
        // down
        if(!downPressed && VelocityZ < 0.0f)
            VelocityZ += Time.deltaTime * deceleration;

        // Clamp to zero for Z axis
        if(!upPressed && !downPressed && VelocityZ !=0 && (VelocityZ > 0.0f && VelocityZ < 0.05f))
            VelocityZ = 0.0f;

        // Left
        if(!leftPressed && VelocityX < 0.0f)
            VelocityX += Time.deltaTime * deceleration;

        // Right
        if(!rightPressed && VelocityX > 0.0f)
            VelocityX -= Time.deltaTime * deceleration;

        // clamp to zero for X axis
        if(!leftPressed && !rightPressed && VelocityX != 0.0f && (VelocityX > -0.05f && VelocityX < 0.05f))
            VelocityX = 0.0f;

        // Clamps
        if(upPressed && VelocityZ > maxRunVelocity)
            VelocityZ = maxRunVelocity;
        if(downPressed && VelocityZ < -maxRunVelocity)
            VelocityZ = -maxRunVelocity;
        if(leftPressed && VelocityX < -maxRunVelocity)
            VelocityX = -maxRunVelocity;
        if(rightPressed && VelocityX > maxRunVelocity)
            VelocityX = maxRunVelocity;    

        animator.SetFloat(VelocityZHash, VelocityZ);
        animator.SetFloat(VelocityXHash, VelocityX);
    }
}
