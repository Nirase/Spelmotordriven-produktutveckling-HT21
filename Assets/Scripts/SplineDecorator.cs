using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineDecorator : MonoBehaviour
{
    [SerializeField]
    BezierSpline spline;
    [SerializeField]
    int frequency;
    [SerializeField]
    Transform item;

    void Awake()
    {
        if(frequency <= 0  || item == null)
        {
            return;
        }
        float stepSize;
        if (spline.Loop)
        {
            stepSize = 1f / frequency;
        }
        else
        {
            stepSize = 1f / (frequency - 1);
        }
        for (int p = 0, f = 0 ; f < frequency; f++, p++)
        {
            Transform spawnedItem = Instantiate(item) as Transform;
            Vector3 position = spline.GetPoint(p * stepSize);
            spawnedItem.localPosition = position;
            spawnedItem.parent = transform;
        }
    }
}
