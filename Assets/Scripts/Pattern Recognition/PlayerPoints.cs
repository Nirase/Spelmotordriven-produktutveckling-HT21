using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField]
    public Vector3[] points;
    int index;

    void Start()
    {
        points = new Vector3[50];
        index = 0;
        StartCoroutine(savePos());
    }

    IEnumerator savePos()
    {
        while (true)
        {

            points[index] = transform.position;
            index++;
            index = index < 50 ? index : 0;
            yield return new WaitForSeconds(0.12f);
        }
    }
}