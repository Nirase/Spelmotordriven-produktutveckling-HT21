using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform goal;
    [SerializeField] Transform start;
    [SerializeField] ColorManager colorManager;
    [SerializeField] ColorRemapTYPE colorType;

    [SerializeField, Range(20, 100)] int detectionDistance = 50;
    private NavMeshAgent agent;
    bool following = false;
    bool fleeing = false;
    public bool destinationReached = false;
   // Vector3 playerLookAtTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        transform.position = start.position;

    }

    void Update()
    {
       // playerLookAtTarget = new Vector3(player.position.x, transform.position.y, player.position.z);

        Vector3 playerPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        Vector3 startToPlayer = playerPos - start.position;

        // Follow player
        if (startToPlayer.magnitude <= detectionDistance && !following && !fleeing)
        {
            agent.destination = playerPos;
            following = true;
            StartCoroutine(ColorManager.UnlockColor(colorManager, colorType));
            
            //agent.transform.LookAt(playerLookAtTarget);
        }
        
        // Keep following player.
        if(following)
        {
           // agent.transform.LookAt(playerLookAtTarget);
            agent.destination = playerPos;
        }

        // If too far away from player, stay where you are. Possibly check for LOS?
        Vector3 fishToPlayer = playerPos - transform.position;
        if(fishToPlayer.magnitude > detectionDistance && following && !fleeing)
        {
            following = false;
            agent.destination = start.position;
            StartCoroutine(ColorManager.LockColor(colorManager, colorType));
        }

        // Move to goal
        Vector3 fishToGoal = goal.transform.position - transform.position;
        if (fishToGoal.magnitude <= detectionDistance && !fleeing)
        {
            //agent.transform.LookAt(goal);
            agent.destination = goal.position;
            destinationReached = true;
            following = false;
        }

        // Flee to start
        Vector3 fishToStart = start.position - transform.position;
        if (fleeing)
        {
            agent.destination = start.position;
            if(fleeing && fishToStart.magnitude <= detectionDistance)
                fleeing = false;
            StartCoroutine(ColorManager.LockColor(colorManager, colorType));
        }
    }
    public NavMeshAgent GetAgent()
    {
        return agent;
    }

    public void Flee()
    {
        agent.destination = start.position;
        fleeing = true;
        following = false;
    }
}
