using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADMouse_NoRhythm : MonoBehaviour
{
    public float Speed = 10f;
    public float VelocityMax = 15f;

    private Rigidbody body;

    bool movePlayer = false;
    KeyCode lastInput;
    public Camera camera;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        
        if(plane.Raycast(ray, out distance)) {
            Vector3 target=ray.GetPoint(distance);
            Vector3 direction=target-transform.position;
            float rotation  = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg;
            transform.rotation=Quaternion.Euler(0, rotation, 0);
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
        body.velocity = Vector3.ClampMagnitude(body.velocity, VelocityMax);
        movePlayer = false;
    }
}
