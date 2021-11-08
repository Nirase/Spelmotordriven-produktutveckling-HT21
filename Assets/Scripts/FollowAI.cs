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
        agent.speed = 5;
    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        Vector3 startToPlayer = playerPos - start.transform.position;

        if (startToPlayer.magnitude <= detectionDistance)
            agent.destination = playerPos;
        else
            agent.destination = start.transform.position;

        
        Vector3 fishToGoal = goal.transform.position - transform.position;
        
        if (fishToGoal.magnitude <= detectionDistance)
            agent.destination = goal.transform.position;





    }
}
