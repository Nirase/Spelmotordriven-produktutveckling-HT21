using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform goal;
    [SerializeField] Transform start;

    [SerializeField, Range(20, 100)] int detectionDistance = 50;
    private NavMeshAgent agent;
    bool following = false;
    bool fleeing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        transform.position = start.position;
        agent.speed = 25f;
        agent.stoppingDistance = 10f;
    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        Vector3 startToPlayer = playerPos - start.position;

        // Follow player
        if (startToPlayer.magnitude <= detectionDistance && !following && !fleeing)
        {
            agent.destination = playerPos;
            following = true;
        }
        
        // Keep following player.
        if(following)
            agent.destination = playerPos;

        // If too far away from player, stay where you are. Possibly check for LOS?
        Vector3 fishToPlayer = playerPos - transform.position;
        if(fishToPlayer.magnitude > detectionDistance && following && !fleeing)
        {
            following = false;
            agent.destination = start.position;
        }

        // Move to goal
        Vector3 fishToGoal = goal.transform.position - transform.position;
        if (fishToGoal.magnitude <= detectionDistance && !fleeing)
        {
            agent.destination = goal.position;
            following = false;
        }

        // Flee to start
        Vector3 fishToStart = start.position - transform.position;
        if (fleeing)
        {
            agent.destination = start.position;
            if(fleeing && fishToStart.magnitude <= detectionDistance)
                fleeing = false;
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
    }

    public int LighthouseEscort()
    {
        if(agent.remainingDistance < 5f)
            return 1;
        else
            return 0;
    }
}
