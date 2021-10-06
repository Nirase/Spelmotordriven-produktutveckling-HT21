using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvoidAI : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent agent;
    [SerializeField] float triggerDist = 10;
    bool isChased;
    Vector3 startPos;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        isChased = false;
        startPos = agent.transform.position;
    }

    private void Update()
    {
        if (Vector3.Magnitude(agent.transform.position - player.position) < triggerDist)
            isChased = true;
        else
            isChased = false;

        Vector3 dir = agent.transform.position - player.position;
        Vector3 dest = agent.transform.position + dir;


        if (isChased)
        {
            agent.speed = 20;
            agent.destination = dest;
        }
        else
        {
            agent.speed = 5;
            agent.destination = startPos;
        }

    }


}
