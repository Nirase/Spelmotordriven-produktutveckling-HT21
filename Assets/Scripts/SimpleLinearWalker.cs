using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLinearWalker : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    
    [SerializeField, Range(1, 100)] float speed = 25f;
    float distance = 5f;
    Vector3 dir;


    void Update()
    {
        if(dir.magnitude < distance)
            Destroy(this);
        dir = end.position - transform.position;
        transform.position += dir.normalized * speed;
    }
}
