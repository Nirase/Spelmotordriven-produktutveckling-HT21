using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shark : MonoBehaviour
{
    [SerializeField] GoatWolfCabbagePuzzle puzzle;
    [SerializeField] GameObject school;
    [SerializeField] GameObject sharkObject;

    bool spawn = false;
    bool destroy = false;


    private void Start() {
    }
  
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Goat") || other.CompareTag("Wolf") || other.CompareTag("Cabbage"))
        {
            other.gameObject.GetComponent<FollowAI>().Flee();
        }
    }

    private void Update() {
        if(puzzle.completed)
        {
            if(!destroy)
            {
                Destroy(sharkObject);
                destroy = true;
            }

            if(!spawn)
            { 
                Instantiate(school, transform);
                spawn = true;
            }
        }

    }
}
