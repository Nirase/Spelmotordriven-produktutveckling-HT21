using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockUnit : MonoBehaviour
{
    [SerializeField] float fOVAngle;
    [SerializeField] float smoothDamp;

    List<FlockUnit> neigbhours = new List<FlockUnit>();
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
        Vector3 cohesionVector = CalculateCohesionVector();
        var moveVector = Vector3.SmoothDamp(transform.forward, cohesionVector, ref currentVelocity, smoothDamp);
        moveVector = moveVector.normalized * speed;
        transform.forward = moveVector;
        transform.position +=  moveVector * Time.deltaTime;
    }

    void FindNeibhours()
    {
        neigbhours.Clear();
        var allUnits = assignedFlock.allUnits;
        for (int i = 0; i < allUnits.Length; i++)
        {
            var currentUnit = allUnits[i];
            if(currentUnit != this)
            {
                float currentNeibhoursDistanceSqr = Vector3.SqrMagnitude(currentUnit.transform.position - transform.position);
                if(currentNeibhoursDistanceSqr <= assignedFlock.cohesionDistance * assignedFlock.cohesionDistance)
                {
                    neigbhours.Add(currentUnit);
                }
            }
        }
    }
    Vector3 CalculateCohesionVector()
    {
        var cohesionVector = Vector3.zero;
        if (neigbhours.Count == 0)
            return cohesionVector;
        int neigbhoursInFOV = 0;
        for (int i = 0; i < neigbhours.Count; i++)
        {
            if (IsInFOV(neigbhours[i].transform.position))
            {
                neigbhoursInFOV++;
                cohesionVector += neigbhours[i].transform.position;
            }
        }
        if (neigbhoursInFOV == 0)
            return cohesionVector;

        cohesionVector /= neigbhoursInFOV;
        cohesionVector -= transform.position;
        cohesionVector = cohesionVector.normalized;
        return cohesionVector;
    }

    bool IsInFOV(Vector3 position)
    {
        return Vector3.Angle(transform.forward, position - transform.position) <= fOVAngle;
    }
}
