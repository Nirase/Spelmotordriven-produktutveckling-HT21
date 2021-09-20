using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockUnit : MonoBehaviour
{
    [SerializeField] float fOVAngle;
    [SerializeField] float smoothDamp;

    List<FlockUnit> cohesionNeigbhours = new List<FlockUnit>();
    List<FlockUnit> avoidanceNeigbhours = new List<FlockUnit>();
    List<FlockUnit> alignmentNeigbhours = new List<FlockUnit>();

    Flock assignedFlock;
    Vector3 currentVelocity;
    float speed;

    public void AssignFlocked(Flock flock)
    {
        assignedFlock = flock;
    }

    public void InitializeSpeed(float speed)
    {
        this.speed = speed;
    }

    public void MoveUnit()
    {
        FindNeibhours();
        CalculateSpeed();

        var cohesionVector = CalculateCohesionVector() * assignedFlock.cohesionWeight;
        var avoidanceVector = CalculateAvoidanceVector() * assignedFlock.avoidanceWeight;
        var alignmentVector = CalculateAlignmentVector() * assignedFlock.alignmentWeight;
        var boundsVector = CalculateBoundsVector() * assignedFlock.boundsWeight;

        var moveVector = cohesionVector + avoidanceVector + alignmentVector + boundsVector;
        moveVector = Vector3.SmoothDamp(transform.forward, moveVector, ref currentVelocity, smoothDamp);
        moveVector = moveVector.normalized * speed;
        if (moveVector == Vector3.zero)
            moveVector = transform.forward;

        transform.forward = moveVector;
        transform.position +=  moveVector * Time.deltaTime;
    }

    Vector3 CalculateBoundsVector()
    {
        var centerOffset = assignedFlock.transform.position - transform.position;
        bool isNearCenter = (centerOffset.magnitude >= assignedFlock.boundsDistance * 0.8f);
        return isNearCenter ? centerOffset.normalized : Vector3.zero;
    }

    Vector3 CalculateCohesionVector()
    {
        var cohesionVector = Vector3.zero;
        if (cohesionNeigbhours.Count == 0)
            return cohesionVector;
        int neigbhoursInFOV = 0;
        for (int i = 0; i < cohesionNeigbhours.Count; i++)
        {
            if (IsInFOV(cohesionNeigbhours[i].transform.position))
            {
                neigbhoursInFOV++;
                cohesionVector += cohesionNeigbhours[i].transform.position;
            }
        }
        if (neigbhoursInFOV == 0)
            return cohesionVector;

        cohesionVector /= neigbhoursInFOV;
        cohesionVector -= transform.position;
        cohesionVector = cohesionVector.normalized;
        return cohesionVector;
    }

    Vector3 CalculateAvoidanceVector()
    {
        var avoidanceVector = Vector3.zero;
        if (alignmentNeigbhours.Count == 0)
            return avoidanceVector;
        int neighboursInFOV = 0;
        for (int i = 0; i < avoidanceNeigbhours.Count; i++)
        {
            if (IsInFOV(avoidanceNeigbhours[i].transform.position))
            {
                neighboursInFOV++;
                avoidanceVector += (transform.position - avoidanceNeigbhours[i].transform.position);
            }
        }
        if (neighboursInFOV == 0)
            return avoidanceVector;
        avoidanceVector /= neighboursInFOV;
        avoidanceVector = avoidanceVector.normalized;
        return avoidanceVector;
    }
    Vector3 CalculateAlignmentVector()
    {
        var alignmentVector = transform.forward;
        if (alignmentNeigbhours.Count == 0)
            return alignmentVector;
        int neighboursInFOV = 0;
        for (int i = 0; i < alignmentNeigbhours.Count; i++)
        {
            if (IsInFOV(alignmentNeigbhours[i].transform.position))
            {
                neighboursInFOV++;
                alignmentVector += alignmentNeigbhours[i].transform.forward;
            }
        }
        if (neighboursInFOV == 0)
            return alignmentVector;
        alignmentVector /= neighboursInFOV;
        alignmentVector = alignmentVector.normalized;
        return alignmentVector;
    }

    void CalculateSpeed()
    {
        if (cohesionNeigbhours.Count == 0)
            return;

        speed = 0;
        for (int i = 0; i < cohesionNeigbhours.Count; i++)
        {
            speed += cohesionNeigbhours[i].speed;
        }
        speed /= cohesionNeigbhours.Count;
        speed = Mathf.Clamp(speed, assignedFlock.minSpeed, assignedFlock.maxSpeed);
    }

    void FindNeibhours()
    {
        cohesionNeigbhours.Clear();
        avoidanceNeigbhours.Clear();
        alignmentNeigbhours.Clear();
        var allUnits = assignedFlock.allUnits;
        for (int i = 0; i < allUnits.Length; i++)
        {
            var currentUnit = allUnits[i];
            if(currentUnit != this)
            {
                float currentNeibhoursDistanceSqr = Vector3.SqrMagnitude(currentUnit.transform.position - transform.position);
                if(currentNeibhoursDistanceSqr <= assignedFlock.cohesionDistance * assignedFlock.cohesionDistance)
                {
                    cohesionNeigbhours.Add(currentUnit);
                }
                if (currentNeibhoursDistanceSqr <= assignedFlock.avoidanceDistance * assignedFlock.avoidanceDistance)
                {
                    avoidanceNeigbhours.Add(currentUnit);
                }
                if (currentNeibhoursDistanceSqr <= assignedFlock.alignmentDistance * assignedFlock.alignmentDistance)
                {
                    alignmentNeigbhours.Add(currentUnit);
                }
            }
        }
    }
    bool IsInFOV(Vector3 position)
    {
        return Vector3.Angle(transform.forward, position - transform.position) <= fOVAngle;
    }
}
