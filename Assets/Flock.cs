using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [Header("Spawn Setup")]
    [SerializeField] FlockUnit flockUnitPrefab;
    [SerializeField] int flockSize;
    [SerializeField] Vector3 spawnBounds;

    [Header("Speed Setup")]
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    [Header("Detection Distances")]
    [SerializeField, Range(0, 10)] float _cohesionDistance;

    public float cohesionDistance { get { return _cohesionDistance; } }

    public FlockUnit[] allUnits { get; set; }
    void Start()
    {
        GenerateUnits();
    }

    void GenerateUnits()
    {
        allUnits = new FlockUnit[flockSize];
        for (int i = 0; i < flockSize; i++)
        {
            var randomVector = Random.insideUnitSphere;
            randomVector = new Vector3(randomVector.x * spawnBounds.x, randomVector.y * spawnBounds.y, randomVector.z * spawnBounds.z);
            var spawnPosition = transform.position + randomVector;
            var rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            allUnits[i] = Instantiate(flockUnitPrefab, spawnPosition, rotation);
            allUnits[i].AssignFlocked(this);
            allUnits[i].InitializeSpeed(Random.Range(minSpeed, maxSpeed));
        }
    }

    void Update()
    {
        foreach (FlockUnit unit in allUnits)
        {
            unit.MoveUnit();
        }
    }
}
