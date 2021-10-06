using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollowAI : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent agent;
    Vector3 startPos;
    [SerializeField] float triggerDist = 10;
    [SerializeField] Transform goal;
    bool isFinished;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        startPos = agent.transform.position;
        isFinished = false;
    }
    void Update()
    {

        if (Vector3.Magnitude(agent.transform.position - goal.position) <= 20)
            isFinished = true;

        if (!isFinished)
        {
            if (Vector3.Magnitude(agent.transform.position - player.position) < triggerDist)
                agent.destination = player.position;
            else
                agent.destination = startPos;
        }
        else
            agent.destination = agent.transform.position;
        
    }
}
