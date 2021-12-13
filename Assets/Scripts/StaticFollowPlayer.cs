using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFollowPlayer : MonoBehaviour
{
    // This script is a simple static camera

    [SerializeField] Transform Target;
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 15;
    [SerializeField] private float z = -10;

    
    Vector3 offSet;
    void Start()
    {
        offSet = new Vector3(x, y, z);
        transform.position = Target.transform.position + offSet;
    }

    void Update()
    {
        transform.position = Target.position + offSet;
    }
}
