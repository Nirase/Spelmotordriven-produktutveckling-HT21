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

    float turnSmoothTime = 0.08f;
    float turnSmoothVelocity;


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

        if (inputs.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputs.x, inputs.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }


    }

    private void FixedUpdate()
    {
            rb.AddForce(inputs * Force * Time.fixedDeltaTime, ForceMode.Force); // Possibly use impulse instead.
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, VelocityMax);
    }
}
