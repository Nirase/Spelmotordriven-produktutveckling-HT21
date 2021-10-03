using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareLines : MonoBehaviour
{
    [SerializeField]
    Vector3[] points;
    [SerializeField]
    PlayerPoints player;
    [SerializeField]
    float dist;
    int index;

    void Start()
    {
        points = new Vector3[50];
        index = 0;
        StartCoroutine(savePos());
        StartCoroutine(checkPos());
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

    IEnumerator checkPos()
    {

        while (true)
        {
            int coverageCount = 0;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].sqrMagnitude == 0 || player.points[i].sqrMagnitude == 0)
                    continue;
                if ((points[i] - player.points[i]).sqrMagnitude <= dist * dist)
                {
                    coverageCount++;
                }

                if (coverageCount >= 40)
                {
                    Debug.Log("90% completed");
                }
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
