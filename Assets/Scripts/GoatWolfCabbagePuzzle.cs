using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoatWolfCabbagePuzzle : MonoBehaviour
{
    [SerializeField] FollowAI wolf;
    [SerializeField] FollowAI goat;
    [SerializeField] FollowAI cabbage;
    List<FollowAI> list;
    private bool completed = false;
    float distance = 10f;

    void Start()
    {
        list = new List<FollowAI>(); 
        list.Clear();
    }

    void Update()
    {
        HandleEnterExit();

        // Success
        if(list.Count == 3)
        {
            completed = true;
            Debug.Log("Puzzle completed");
        }

        // Fail states - Cut due to not being communicated clearly.
        // if(!completed)
        // {
        //     if(list.Contains(wolf) && list.Contains(goat))
        //     {
        //         Debug.Log("Fail state - Goat cabbage");
        //         goat.Flee();

        //     }
        //     if(list.Contains(goat) && list.Contains(cabbage))
        //     {
        //         Debug.Log("Fail state - Goat cabbage");
        //         cabbage.Flee();
                
        //     }
        //     if(list.Contains(wolf) && list.Contains(goat))
        //     {
        //         goat.Flee();
        //     }
        // }
   
        // Solution to problem:
        // Take the goat(A) over
        
        // Return
        
        // Take the wolf(B) or cabbage(C) over

        // Return with the goat(A) // i.e. same ass flee
        
        // Take the cabbage(C) or wolf(B) over
        
        // Return
        
        // Take goat over(A)
    }
    
    private void HandleEnterExit(){

        Vector3 d_wolf = transform.position - wolf.transform.position;
        Vector3 d_goat = transform.position - goat.transform.position;
        Vector3 d_cabbage = transform.position - cabbage.transform.position;

        // Cabbage
        if(d_cabbage.magnitude < distance  && !list.Contains(cabbage)){
            list.Add(cabbage);
            Debug.Log("Cabbage enter");
        }
        if(d_cabbage.magnitude > distance  && list.Contains(cabbage)){
            list.Remove(cabbage);
            Debug.Log("Cabbage exit");
        }
        // Goat
        if(d_goat.magnitude < distance  && !list.Contains(goat)){
            list.Add(goat);
            Debug.Log("Goat enter");
        }
        if(d_goat.magnitude > distance  && list.Contains(goat)){
            list.Remove(goat);
            Debug.Log("Goat exit");
        }
        // Wolf
        if(d_wolf.magnitude < distance  && !list.Contains(wolf)){
            list.Add(wolf);
            Debug.Log("Wolf enter");
        }
        if(d_wolf.magnitude > distance  && list.Contains(wolf)){
            list.Remove(wolf);
            Debug.Log("Wolf exit");
        }
    }
}
