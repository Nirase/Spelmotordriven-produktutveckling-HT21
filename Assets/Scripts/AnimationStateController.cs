using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator _animator; 
    float VelocityY = 0;
    float DirectionX = 0;

    [SerializeField, Range(0, 2)] float Acceleration = 0.2f;
    public float maxRunVelocity;

    int VelocityYHash;
    int DirectionXHash;

    bool isThrusting = false; 
    [SerializeField, Range(0, 1000)] float ThrustThreshold = 600;
    ADLean_Rigidbody_Controller AD_Controller;

    void Start()
    {
        _animator = GetComponent<Animator>();
        VelocityYHash = Animator.StringToHash("VelocityY");
        DirectionXHash = Animator.StringToHash("DirectionX");
        
        AD_Controller = GetComponent<ADLean_Rigidbody_Controller>();
        maxRunVelocity = AD_Controller.VelocityMax;
    }

    void Update()
    {
        // Forward velocity
        VelocityY = AD_Controller.displaySpeed / AD_Controller.VelocityMax; 
        
        // Find active rotation
        Vector3 targetDir = AD_Controller._direction;
        Vector3 forward = transform.forward;
        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        
        // Get thrust
        float thrust = AD_Controller.Thrust;

        if(thrust > ThrustThreshold)
            isThrusting = true;
        else
            isThrusting = false;

        if(isThrusting)
              SmoothTransitionDirectionX();
        else if(!isThrusting)
        {
            if(angle < -5.0f) // Turning Right
                DirectionX += Time.deltaTime * Acceleration; 
            else if(angle > 5.0f) // Turning left
                DirectionX -= Time.deltaTime * Acceleration; 
            else
               SmoothTransitionDirectionX();
            DirectionX = Mathf.Clamp(DirectionX, -1, 1);
        }

        Debug.Log(DirectionX);
        _animator.SetFloat(VelocityYHash, VelocityY);
        _animator.SetFloat(DirectionXHash, DirectionX);
    }

    public void SmoothTransitionDirectionX()
    {       
        // Clamp at 0
        if(DirectionX != 0.0f && (DirectionX > -0.05f && DirectionX < 0.05f))
            DirectionX = 0.0f;

        // Deaceleration
        if(DirectionX < 0)
            DirectionX += Time.deltaTime * Acceleration; 
        else if(DirectionX > 0)
            DirectionX -= Time.deltaTime * Acceleration; 
    }
}