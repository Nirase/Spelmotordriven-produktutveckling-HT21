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
    [SerializeField] float _minSpeed;
    [SerializeField] float _maxSpeed;

    public float minSpeed { get { return _minSpeed; } }
    public float maxSpeed { get { return _maxSpeed; } }

    [Header("Detection Distances")]
    [SerializeField, Range(0, 10)] float _cohesionDistance;
    [SerializeField, Range(0, 10)] float _avoidanceDistance;
    [SerializeField, Range(0, 10)] float _alignmentDistance;

    public float cohesionDistance { get { return _cohesionDistance; } }
    public float avoidanceDistance { get { return _avoidanceDistance; } }
    public float alignmentDistance { get { return _alignmentDistance; } }

    [Header("Behavoir Weights")]
    [SerializeField, Range(0, 10)] float _cohesionWeight;
    [SerializeField, Range(0, 10)] float _avoidanceWeight;
    [SerializeField, Range(0, 10)] float _alignmentWeight;

    public float cohesionWeight { get { return _cohesionWeight; } }
    public float avoidanceWeight { get { return _avoidanceWeight; } }
    public float alignmentWeight { get { return _alignmentWeight; } }

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
