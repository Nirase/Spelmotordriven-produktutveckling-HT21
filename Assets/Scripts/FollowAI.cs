using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform goal;
    [SerializeField] Transform start;

    [SerializeField] int detectionDistance = 20;
    

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        transform.position = start.position;
        agent.speed = 5;
    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        Vector3 startToPlayer = playerPos - start.position;

        if (startToPlayer.magnitude <= detectionDistance)
            agent.destination = playerPos;
        else
            agent.destination = start.position;

        
        Vector3 fishToGoal = goal.transform.position - transform.position;
        
        if (fishToGoal.magnitude <= detectionDistance)
            agent.destination = goal.position;





    }
}
