using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Controller : MonoBehaviour
{
    Rigidbody rb;
    Vector3 inputs;

    [SerializeField, Range(0, 5000)]
    float Force = 2500;


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
        rb.AddForce(inputs * Force * Time.fixedDeltaTime);
    }
}
