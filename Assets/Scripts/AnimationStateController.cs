using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator; 
    float VelocityY = 0;
    float DirectionX = 0;

    float angle;
    public float acceleration = 0.2f;
    public float deceleration = 2f;
    public float maxRunVelocity;

    int VelocityYHash;
    int DirectionXHash;

    ADLean_Rigidbody_Controller AD_Controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityYHash = Animator.StringToHash("VelocityY");
        DirectionXHash = Animator.StringToHash("DirectionX");
        
        AD_Controller = GetComponent<ADLean_Rigidbody_Controller>();
        maxRunVelocity = AD_Controller.VelocityMax;
    }

    void Update()
    {
        VelocityY = AD_Controller.displaySpeed / AD_Controller.VelocityMax; 


        // Delta rot
        //float angle = Vector3.Angle(AD_Controller.transform.forward, AD_Controller._direction);
        //DirectionX = AD_Controller.angle;

        // float targetAngle = Mathf.Atan2(AD_Controller._direction.x, AD_Controller._direction.z) * Mathf.Rad2Deg;
        // angle = Mathf.angle

        Vector3 dir = AD_Controller._direction;
        dir = Vector3.ClampMagnitude(dir, 1);
        dir = Vector3.ClampMagnitude(dir, -1);

        if(dir.x > transform.forward.z)
        {
            DirectionX += Time.deltaTime * acceleration;
            // Right turn
        }
        if(dir.x < transform.forward.z)
        {
            DirectionX -= Time.deltaTime * acceleration;
            // Left turn
        }

        DirectionX = Mathf.Clamp(DirectionX, -1, 1);
 

        Debug.Log(DirectionX);
        // if(angle > 0)
        //     DirectionX += Time.deltaTime * acceleration;


        animator.SetFloat(VelocityYHash, VelocityY);
        animator.SetFloat(DirectionXHash, DirectionX);


        // Todo:
        // Some way to find direction from mouse

    // Get input
        // bool upPressed = Input.GetKey(KeyCode.W);
        // bool downPressed = Input.GetKey(KeyCode.S);
        // bool leftPressed = Input.GetKey(KeyCode.A);
        // bool rightPressed = Input.GetKey(KeyCode.D);

    //Acceleration
        // A
        // if(leftPressed && VelocityY < maxRunVelocity)
        //     VelocityY += Time.deltaTime * acceleration;
        
        // // D
        // if(rightPressed && VelocityY < maxRunVelocity)
        //     VelocityY += Time.deltaTime * acceleration;




        // Redo for turn left and right
        // up
        // if(upPressed && VelocityZ < maxRunVelocity)
        //     VelocityZ += Time.deltaTime * acceleration;
        
        // // down
        // if(downPressed && VelocityZ > - maxRunVelocity)
        //     VelocityZ -= Time.deltaTime * acceleration;

 

    // Deceleration
        // up
        // if(!leftPressed && VelocityY > 0.0f)
        //     VelocityY -= Time.deltaTime * deceleration;
        
        // // down
        // if(!rightPressed && VelocityY > 0.0f)
        //     VelocityY -= Time.deltaTime * deceleration;

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

    }
}