using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ADLRLean : MonoBehaviour
{
        public float Speed = 250f;
        public float turnSpeed = 1;
        private Rigidbody body;
        bool movePlayer = false;
        KeyCode lastInput;
        void Start()
        {
            body = GetComponent<Rigidbody>();
        }
    
        void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.forward += Quaternion.AngleAxis(turnSpeed, transform.up) * transform.forward;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.forward += Quaternion.AngleAxis(-turnSpeed, transform.up) * transform.forward;
            }
            
            if (Input.GetKeyDown(KeyCode.A) && lastInput != KeyCode.A)
            {
                lastInput = KeyCode.A;
                movePlayer = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && lastInput != KeyCode.D)
            {
                lastInput = KeyCode.D;
                movePlayer = true;
            }
    
        }
        private void FixedUpdate()
        {
            if (movePlayer == false)
                return;
            body.velocity += transform.forward * Speed * Time.fixedDeltaTime;
            movePlayer = false;
        }
}
