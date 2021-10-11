using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_RigidbodyController : MonoBehaviour
{
    // Interpolation should be on since the movement is physics based and therefore seperated from the graphics
    // Mass and force are connected. Adjusting mass also adjusts force.
    // AngularDrag = 0.15-0.18f

    Rigidbody _rigidbody;
    private Vector3 _direction;

    [SerializeField] float Thrust = 100f;
    [SerializeField] float VelocityMax = 10f;

    float turnSmoothVelocity;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    void Start()
    {
        Thrust = _rigidbody.mass * Thrust;
        // Things to possibly add:
        // Center of Mass?
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
    // As of now the rotation is quicker when covering a largle, inversely it is slower when covering a smaller angle.
    // The feel is good, so i'm keeping it as is for now.
    public void Rotate()
    {
        if (_direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(_rigidbody.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, _rigidbody.angularDrag);
            Quaternion rot = Quaternion.Euler(0, angle, 0);
            _rigidbody.MoveRotation(rot);
        }
    }

    // This section handles physics, i.e. movement computations.
    private void FixedUpdate()
    {
        Move();
        Rotate();

        // Fixes: Gravity needs a bit more oumphf
        //_rigidbody.AddForce(new Vector3(0, 1.0f, 0) * Mathf.Pow(_rigidbody.mass, 2) * -9.82f);
    }


}
