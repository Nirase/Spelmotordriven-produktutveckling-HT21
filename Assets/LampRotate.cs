using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampRotate : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float angleThreshold = 90;
    [SerializeField] float distanceThreshold = 50;
    [SerializeField, Range(-100, 100)] float inViewRotSpeed;
    [SerializeField, Range(-100, 100)] float outOfViewRotSpeed;

    void Update()
    {
        Vector3 playerPos = new Vector3(player.position.x, 0, player.position.z);
        Vector3 lampPos = new Vector3(transform.position.x, 0, transform.position.z);
        float angle = Vector3.Angle((playerPos - lampPos).normalized, -transform.forward);
        
        float rotationSpeed = 0;
        if (Vector3.Distance(playerPos, lampPos) < distanceThreshold || angle < angleThreshold)
            rotationSpeed = inViewRotSpeed;
        else
            rotationSpeed = outOfViewRotSpeed;
                
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
    }
}
