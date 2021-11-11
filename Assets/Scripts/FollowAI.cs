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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        transform.position = start.position;
        agent.speed = 5f;
        agent.stoppingDistance = 10f;
    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        Vector3 startToPlayer = playerPos - start.position;

        // Follow player
        if (startToPlayer.magnitude <= detectionDistance && !following)
        {
            agent.destination = playerPos;
            following = true;
        }
        
        // Keep following player.
        if(following)
            agent.destination = playerPos;

        // If too far away from player, stay where you are. Possibly check for LOS?
        Vector3 fishToPlayer = playerPos - transform.position;
        if(fishToPlayer.magnitude > detectionDistance && following)
        {
            following = false;
            agent.destination = start.position;
        }

        // Move to goal
        Vector3 fishToGoal = goal.transform.position - transform.position;
        if (fishToGoal.magnitude <= detectionDistance)
        {
            agent.destination = goal.position;
        }

    }
}
