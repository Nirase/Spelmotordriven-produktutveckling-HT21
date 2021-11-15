using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shark : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    
    [SerializeField] FollowAI wolf;
    [SerializeField] FollowAI goat;
    [SerializeField] FollowAI cabbage;

    Vector3 sharkToEnd;
    Vector3 sharkToStart;
    private NavMeshAgent agent;
    float distance = 10f;
    [SerializeField, Range(1, 10)] float fleeDistance = 5f;

    bool reverse = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        transform.position = start.position;
    }

    void Update()
    {
        sharkToEnd = end.transform.position - transform.position;
        sharkToStart = start.transform.position - transform.position;

        if(!reverse)
            agent.destination = end.transform.position;
        else
            agent.destination = start.transform.position;

        if(sharkToEnd.magnitude <= distance)
            reverse = true;

        if(sharkToStart.magnitude <= distance)
            reverse = false;        

        // Cause flee if too close
        Vector3 sharkToWolf = wolf.transform.position - transform.position;
        Vector3 sharkToCabbage = cabbage.transform.position - transform.position;
        Vector3 sharkToGoat = goat.transform.position - transform.position;
        
        if(sharkToWolf.magnitude <= fleeDistance)
            wolf.Flee();

        if(sharkToCabbage.magnitude <= fleeDistance)
            cabbage.Flee();

        if(sharkToGoat.magnitude <= fleeDistance)
            goat.Flee();

    }
}
