using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoatWolfCabbagePuzzle : MonoBehaviour
{


    [SerializeField] FollowAI wolf;
    [SerializeField] FollowAI goat;
    [SerializeField] FollowAI cabbage;
    List<FollowAI> list;
    private bool completed = false;

    void Start()
    {
        list = new List<FollowAI>(); 

        // wolf = GameObject.FindGameObjectWithTag("Wolf");
        // goat = GameObject.FindGameObjectWithTag("Goat");
        // cabbage = GameObject.FindGameObjectWithTag("Cabbage");
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Wolf")
            list.Add(wolf);
        if(other.tag == "Cabbage")
            list.Add(cabbage);
        if(other.tag == "Goat")
            list.Add(goat);
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Wolf")
            list.Remove(wolf);
        if(other.tag == "Cabbage")
            list.Remove(cabbage);
        if(other.tag == "Goat")
            list.Remove(goat);
    }

    void Update()
    {
        if(list.Contains(wolf) && list.Contains(cabbage) && list.Contains(goat))
            completed = true;


        if(!completed)
        {
            if(list.Contains(wolf) && list.Contains(goat))
            {
                goat.Flee();
                //wolf.GetAgent().SetDestination(goat.transform.position);
            }

            if(list.Contains(wolf) && list.Contains(cabbage))
            {
                // stay
            }

            if(list.Contains(goat) && list.Contains(cabbage))
            {
                cabbage.Flee();
                //goat.GetAgent().SetDestination(cabbage.transform.position);
            }
        }
    
        
        // Solution to problem:
        // Take the goat(A) over
        
        // Return
        
        // Take the wolf(B) or cabbage(C) over

        // Return with the goat(A) // break, goat instead flees.
        
        // Take the cabbage(C) or wolf(B) over
        
        // Return
        
        // Take goat over(A)
    }
}
