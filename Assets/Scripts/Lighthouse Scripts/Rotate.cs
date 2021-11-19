using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField]Transform origo;
    [SerializeField, Range(-25, 25)] float rotationSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(origo.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
