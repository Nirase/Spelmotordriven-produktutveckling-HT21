using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADMouse_Rhythm : MonoBehaviour
{
    public float Speed = 10f;
    public float VelocityMax = 15f;

    private Rigidbody body;

    bool movePlayer = false;
    KeyCode lastInput;
    public Camera camera;


    // Rhythm:
    public float Bpm = 120;
    private float beatHighlight;
    float active = 1f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        beatHighlight = (60 / Bpm); // 0.5
        StartCoroutine(BeatArea());
    }

    IEnumerator BeatArea() 
    {
        while (true)
        {
            active = 0.4f;
            Debug.Log("BEAT");
            while (active > 0)
            {
                active -= Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.A) && lastInput != KeyCode.A)
                {
                    Debug.Log("LEFT");
                    lastInput = KeyCode.A;
                    movePlayer = true;
                }
                else if (Input.GetKeyDown(KeyCode.D) && lastInput != KeyCode.D)
                {
                    Debug.Log("RIGHT");
                    lastInput = KeyCode.D;
                    movePlayer = true;
                }
                yield return null;
            }
            yield return new WaitForSeconds(0.1f); // 0.5s for 120 bpm
        }
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
