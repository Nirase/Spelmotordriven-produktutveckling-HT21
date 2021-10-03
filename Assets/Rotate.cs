using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField]
    float size;
    [SerializeField]
    float speed;
    float timeCounter = 0;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        float x = Mathf.Cos(timeCounter) * size;
        float z = Mathf.Sin(timeCounter) * size;

        transform.position = new Vector3(x, 0, z) + startPos;
    }
}
