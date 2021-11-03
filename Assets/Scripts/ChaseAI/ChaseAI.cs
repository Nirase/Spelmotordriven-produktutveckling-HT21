using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform goal;
    
    [SerializeField] private int chaseStartDistance = 20;
    [SerializeField] private int chaseMarginal = 30;
    [SerializeField] private int goalMarginal = 10;

    private NavMeshAgent agent;
    private Vector3 startPosition;
    private bool done;
    private bool chaseStarted;

    [SerializeField] private Material colourMaterial;
    void Start()
    {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        var distanceToGoal = (goal.position - transform.position).magnitude;

        if (done)
            return;
        
        if (distanceToGoal <= goalMarginal)
        {
            colourMaterial.SetFloat("colorRemapYellow", 1f);
            done = true;
            return;
        }
        
        var distanceToPlayer = (player.transform.position - transform.position).magnitude;
        
        if (distanceToPlayer < chaseStartDistance && !chaseStarted)
        {
            agent.destination = goal.position;
            chaseStarted = true;
        }

        if (distanceToPlayer > chaseMarginal)
        {
            agent.destination = startPosition;
        }

        if ((transform.position - startPosition).magnitude - 0.1 <= 0)
            chaseStarted = false;
    }
}
