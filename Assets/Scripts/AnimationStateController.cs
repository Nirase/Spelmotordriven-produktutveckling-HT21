using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator; 
    float VelocityY = 0;
    float DirectionX = 0;

    public float acceleration = 0.2f;
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
        // Forward velocity
        VelocityY = AD_Controller.displaySpeed / AD_Controller.VelocityMax; 

        // Rotation
        Vector3 targetDir = AD_Controller._direction;
        Vector3 forward = transform.forward;

        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        
     

        if(angle < -5.0f) // Turning Right
            DirectionX += Time.deltaTime * acceleration; 
        else if(angle > 5.0f) // Turning left
            DirectionX -= Time.deltaTime * acceleration; 
        else
        {   
            // Clamp to 0 at border values
            if(DirectionX != 0.0f && (DirectionX > -0.05f && DirectionX < 0.05f))
                DirectionX = 0.0f;

            // Deaceleration
            if(DirectionX < 0)
                DirectionX += Time.deltaTime * acceleration; 
            else if(DirectionX > 0)
                DirectionX -= Time.deltaTime * acceleration; 
        }
        DirectionX = Mathf.Clamp(DirectionX, -1, 1);
        
        
        Debug.Log(DirectionX);
        animator.SetFloat(VelocityYHash, VelocityY);
        animator.SetFloat(DirectionXHash, DirectionX);



        // float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        // float angle = Mathf.DeltaAngle(AD_Controller.transform.forward.y, targetAngle);
       // DirectionX = AD_Controller.angle / 360;
        //DirectionX = Mathf.Clamp(DirectionX, -1, 1);

 
    
 



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