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
        RIGHT
    }

    List<Collider> colliders = new List<Collider>();
    [SerializeField] private Direction windDirection;

    [SerializeField] private float speed = 1;
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        foreach(var col in colliders)
        {
            col.transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!colliders.Contains(other))
        {
            if(other.CompareTag("Player"))
                colliders.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (colliders.Contains(other))
        {
            if(other.CompareTag("Player"))
                colliders.Remove(other);
        }
    }
}
