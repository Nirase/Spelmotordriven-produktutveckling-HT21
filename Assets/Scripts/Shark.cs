using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shark : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Goat") || other.CompareTag("Wolf") || other.CompareTag("Cabbage"))
        {
            other.gameObject.GetComponent<FollowAI>().Flee();
        }
    }
}
