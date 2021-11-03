using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{

    public float swimSpeed = 0;
    private NavMeshAgent agent;
    
    public Transform[] path;

    public bool loopPath;

    private int current;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        current = 0;
        agent.destination = path[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (current >= path.Length && !loopPath) return;
        if (Vector3.Distance(transform.position, path[current].position) - 1f <= 0)
        {
            if (current == path.Length - 1 && loopPath)
            {
                current = 0;
                agent.destination = path[current].position;
            }
            else
            {
                current++;
                agent.destination = path[current].position;
            }
        }
        if (path[current].position.y > transform.position.y)
        {
            agent.baseOffset += swimSpeed * Time.fixedDeltaTime;
        }
        
        else if (path[current].position.y < transform.position.y)
        {
            agent.baseOffset -= swimSpeed * Time.fixedDeltaTime;
        }

    }
}
