using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPattern : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Collider" + other.name);
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit Collider" + other.name);
    }
}
