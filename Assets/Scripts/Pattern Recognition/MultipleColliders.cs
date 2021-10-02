using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleColliders : MonoBehaviour
{
    [SerializeField]
    GameObject[] points;

    void Update()
    {
        foreach (GameObject item in points)
        {
            if(item.activeSelf == true)
            {
                return;
            }
        }
        Debug.Log("Pattern Followed");
    }
}
