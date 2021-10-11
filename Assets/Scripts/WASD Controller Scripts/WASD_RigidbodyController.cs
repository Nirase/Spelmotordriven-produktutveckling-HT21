using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_RigidbodyController : MonoBehaviour
{
    Rigidbody _rigidbody;
    private Vector3 _direction;

    [SerializeField] float Thrust = 1000f;
    [SerializeField] float VelocityMax = 10f;

    float turnSmoothTime = 0.10f;
    float turnSmoothVelocity;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    void Start()
    {

    }

    // This section is used to manage input and determine logic separate from physics.
    void Update()
    {
        // Should work for all types of controllers. Values for horizontal and vertical are in unity settings.
        // Could also be part of a separate script.
        _direction = Vector3.zero;
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
    }

    public void Move()
    {
        _rigidbody.AddForce(_direction * Thrust * Time.fixedDeltaTime, ForceMode.Force);
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, VelocityMax);
    }


    // Handles the rotation when changing directions.
    public void Rotate()
    {
        if (_direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(_rigidbody.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            Quaternion rot = Quaternion.Euler(0, angle, 0);
            _rigidbody.MoveRotation(rot);
        }
    }

    // This section physics, i.e. movement computations.
    private void FixedUpdate()
    {
        Move();
        Rotate();
    }


}
