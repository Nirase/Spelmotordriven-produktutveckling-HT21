using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADLean_Rigidbody_Controller : MonoBehaviour
{

    // Steer with mouse
    // AD for speed
    // Not rhythm based.

    Rigidbody _rigidbody;
    private Vector3 _direction;

    [SerializeField] float Thrust = 100f;
    [SerializeField] float VelocityMax = 10f;
    public Camera _camera;

    float turnSmoothVelocity;
    bool _movePlayer;
    KeyCode _lastInput;

    float _targetAngle;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    void Start()
    {
        Thrust = _rigidbody.mass * Thrust;
    }

    void Update()
    {
        // Get mouse position, and also direction for player.
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        
        if(plane.Raycast(ray, out distance)) {
            Vector3 target = ray.GetPoint(distance);
            _direction = target - transform.position;
            _direction.Normalize();
        }

        // Add timer so input isnt locked.
        if (Input.GetKeyDown(KeyCode.A) && _lastInput != KeyCode.A)
        {
            _lastInput = KeyCode.A;
            _movePlayer = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _lastInput != KeyCode.D)
        {
            _lastInput = KeyCode.D;
            _movePlayer = true;
        }
    }

    public void Move()
    {   
        if (_movePlayer == false)
            return;


        _rigidbody.AddForce(_direction * Thrust * Time.fixedDeltaTime, ForceMode.Force);
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, VelocityMax);
        
        //_movePlayer = false;
    }

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

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }


}
