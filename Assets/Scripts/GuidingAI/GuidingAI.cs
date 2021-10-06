using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuidingAI : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private Transform player;

    [SerializeField] private float stoppingDistance = 20;
    [SerializeField] private float waitMarginal = 10;
    [SerializeField] private float waitTime = 10;

    private float timeSinceLastInteraction = 0;
    private bool foundPlayer = false;
    private bool searchForPlayer = false;

    [SerializeField] private float speed = 50;
    [SerializeField] private PointOfInterest[] goals;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;

        StartCoroutine(UpdateTime());
        PointOfInterest.ONTriggerEnter += InteractionDone;
    }

    // Update is called once per frame
    void Update()
    {
        if (((player.position - transform.position).magnitude > stoppingDistance) && searchForPlayer)
        {
            agent.stoppingDistance = stoppingDistance;
            agent.destination = player.position;
            foundPlayer = false;
        }
        
        switch (foundPlayer)
        {
            case true:
            {
                var destination = Vector3.positiveInfinity;
                foreach (var poi in goals)
                {
                    var temp = poi.transform.position - player.position;
                    if (temp.magnitude < destination.magnitude && !poi.triggered)
                        destination = poi.transform.position;
                }

                agent.stoppingDistance = 0;
                agent.destination = destination;
                break;
            }
            case false when searchForPlayer && agent.remainingDistance < stoppingDistance - waitMarginal:
                foundPlayer = true;
                break;
        }

        if (timeSinceLastInteraction >= waitTime && !foundPlayer)
        {
            agent.destination = player.position;
            searchForPlayer = true;
        }

        if (timeSinceLastInteraction < waitTime)
        {
            agent.destination = Vector3.zero;
            searchForPlayer = false;
            foundPlayer = false;
        }
    }

    private void InteractionDone()
    {
        timeSinceLastInteraction = 0;
        foundPlayer = false;
        searchForPlayer = false;
    }

    private IEnumerator UpdateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeSinceLastInteraction++;
        }
    }
}
