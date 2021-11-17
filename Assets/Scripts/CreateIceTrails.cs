using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateIceTrails : MonoBehaviour
{
    [SerializeField] GameObject iceTrail;

    GameObject instance;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("IcePlane"))
            return;

        instance = Instantiate(iceTrail, transform);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("IcePlane"))
            return;

        ParticleSystem ps = instance.GetComponent<ParticleSystem>();
        ps.Stop();
        Destroy(instance, ps.main.startLifetime.constantMax + 1);
    }
}
