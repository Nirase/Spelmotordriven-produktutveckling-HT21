using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }

    List<Collider> colliders = new List<Collider>();

    [SerializeField] private bool useOrigin;
    [SerializeField] private Transform origin;
    
    [SerializeField] private Direction windDirection;

    [SerializeField] private float speed = 100;
    [SerializeField, Range(-180, 180)] private float angle = -45;

    Vector3 directionVector;
    // Start is called before the first frame update
    void Start()
    {
        if (useOrigin)
        {
            directionVector = transform.position - origin.position;
            directionVector = Quaternion.Euler(0, angle, 0) * directionVector;
            directionVector.Normalize();

            transform.forward = directionVector;
        }
        else
        {
            switch (windDirection)
            {
                case Direction.UP:
                    break;
                case Direction.RIGHT:
                    transform.Rotate(new Vector3(0, 1,0), 90);
                    break;
                case Direction.DOWN:
                    transform.Rotate(new Vector3(0, 1,0), 180);
                    break;
                case Direction.LEFT:
                    transform.Rotate(new Vector3(0, 1,0), 270);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var col in colliders)
        {                                               // Force to player should be added via transform.right to maintain relative direction.
            col.GetComponent<Rigidbody>().AddForce(transform.right * (speed * Time.deltaTime), ForceMode.Force);
            
            if(Vector3.Dot(transform.forward, col.transform.forward) < 0)
                col.GetComponent<ADLean_Rigidbody_Controller>().wind = true;
            else
                col.GetComponent<ADLean_Rigidbody_Controller>().wind = false;

        }

        if (useOrigin)
        {
            var directionVector = transform.position - origin.position;
            directionVector = Quaternion.Euler(0, angle, 0) * directionVector;
            directionVector.Normalize();

            transform.forward = directionVector;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!colliders.Contains(other))
        {
            if(other.CompareTag("Player"))
            {
                colliders.Add(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (colliders.Contains(other))
        {
            if(other.CompareTag("Player"))
            {
                other.GetComponent<ADLean_Rigidbody_Controller>().wind = false;
                colliders.Remove(other);
            }
        }
    }
}