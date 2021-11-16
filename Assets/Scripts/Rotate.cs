using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField]Transform origo;
    [SerializeField, Range(1, 25)] float rotationSpeed = 5f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(origo.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
