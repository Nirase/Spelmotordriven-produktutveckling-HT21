using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SplineWalkerMode
{
    Once,
    Loop
}
public class SplineWalker : MonoBehaviour
{
    [SerializeField]
    BezierSpline spline;
    [SerializeField, Range(0.1f, 1000f)]
    float duration;
    [SerializeField]
    bool lookForward;
    [SerializeField]
    SplineWalkerMode mode;
    [SerializeField]
    float offset;

    [SerializeField, Range(0,1f)]
    float progress;
    void Update()
    {
        progress += Time.deltaTime / duration;

        if(progress > 1f)
        {
            if(mode == SplineWalkerMode.Once)
            {
                progress = 1f;
            }
            else if (mode == SplineWalkerMode.Loop)
            {
                progress -= 1f;
            }
        }
        Vector3 position = spline.GetPoint(progress);
        position.y += offset;
        transform.localPosition = position;
        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
    }
}
