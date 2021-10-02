using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCollider : MonoBehaviour
{
    [SerializeField]
    Vector3[] points;
    [SerializeField]
    Transform visual;

    SphereCollider sCollider;
    int index;

    float timer;
    [SerializeField]
    float maxTimer;
    // Start is called before the first frame update
    void Start()
    {        
        sCollider = gameObject.AddComponent<SphereCollider>();
        sCollider.center = points[0];
        visual.localPosition = points[0];
        sCollider.isTrigger = true;
        sCollider.radius = 1;
        index = 0;
        timer = maxTimer;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = maxTimer;
            sCollider.center = points[0];
            visual.localPosition = points[0];
            index = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        index++;
        if (index >= points.Length)
            index = 0;
        sCollider.center = points[index];
        visual.localPosition = points[index];
        timer = maxTimer;
    }
}
