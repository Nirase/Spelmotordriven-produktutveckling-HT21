using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFollowPlayer : MonoBehaviour
{
    // This script is a simple static camera

    [SerializeField] Transform Target;
    Vector3 offSet;
    void Start()
    {
        offSet = new Vector3(0, 15, -10);
        transform.position = Target.transform.position + offSet;
    }

    void Update()
    {
        transform.position = Target.position + offSet;
    }
}
