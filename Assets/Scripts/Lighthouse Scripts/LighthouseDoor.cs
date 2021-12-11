using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseDoor : MonoBehaviour
{
    [SerializeField] GameObject dust_PS;

    void ActivateDirt()
    {
        GameObject go = Instantiate(dust_PS);
        go.GetComponent<ParticleSystem>().Play();
        Destroy(go, 10f);
    }
}
