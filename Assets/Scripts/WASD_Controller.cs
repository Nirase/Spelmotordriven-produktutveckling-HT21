using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Controller : MonoBehaviour
{
    Rigidbody rb;
    Vector3 inputs;

    [SerializeField, Range(0, 500000)]
    float Force = 5000;
    [SerializeField, Range(0, 100)]
    float VelocityMax = 15;

    // Acceleration, read about it. Possibly add.
    // MaxVelocity, to cap velocity.
    // Mass 55-67kg, is the avrage weight of an adult female woman 170cm
    // Lower Vmax and higher force for snappier movement.


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");

        if (inputs != Vector3.zero)
            transform.forward = inputs;


    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < VelocityMax)  
            rb.AddForce(inputs * Force * Time.fixedDeltaTime, ForceMode.Force); // Possibly use impulse instead.
    }
}
