using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADLean_Rigidbody_Controller : MonoBehaviour
{

    // Steer with mouse
    // AD for speed
    // Not rhythm based.

    //Added for lighthouse
    public bool wind = false;
    //
    Rigidbody _rigidbody;

    public float displaySpeed;
    public float RhythmThrust = 300f;
    public float Thrust = 100f;
    [SerializeField] float ThrustDecay = 0.985f;
    public float VelocityMax = 10f;

    KeyCode _lastInput;
    public Camera _camera;
    public Vector3 _direction;
    private Vector3 target = Vector3.zero;
    private float _thrust;
    
    float turnSmoothVelocity; // This is set via angular velocity.
    [SerializeField, Range(0, 5)] float Timer = 2;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    void Start()
    {
        Thrust = _rigidbody.mass * Thrust;
        _thrust = Thrust;
        Thrust = 0; // So we dont start the game moving.
    }

    void Update()
    {
        // Get mouse position, and also direction for player.
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        
        if(plane.Raycast(ray, out distance)) {
            
            target = ray.GetPoint(distance);
            _direction = target - transform.position;
            Debug.DrawLine(transform.position, target, Color.red);
            _direction.Normalize();
        }

        // This resets the input requirement.
        // Possibly add time since last input to prevent spamming AD.
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            Timer = 2f;
            _lastInput = KeyCode.T;
        }

        if (Input.GetKeyDown(KeyCode.A) && _lastInput != KeyCode.A)
        {
            _lastInput = KeyCode.A;
            Thrust = _thrust;
            Timer = 2f;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _lastInput != KeyCode.D)
        {
            _lastInput = KeyCode.D;
            Thrust = _thrust;
            Timer = 2f;
        }
    }

    public void Move()
    {   
        if(wind)
        {   
            Thrust = 0;
            return;
        }
        // If we reach maxvel mass no longer counts, right now we arrive at maxvel to quickly, therefore add more noticable acceleration.
        Thrust = Thrust * ThrustDecay;
        _rigidbody.AddForce(_direction * Thrust * Time.fixedDeltaTime, ForceMode.Force);
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, VelocityMax); 
     
        // For debugging.
        displaySpeed = _rigidbody.velocity.magnitude;
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
