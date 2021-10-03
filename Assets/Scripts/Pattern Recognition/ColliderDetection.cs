using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    [SerializeField]
    MultipleColliders mc;
    [SerializeField]
    public int id;
    void OnTriggerEnter(Collider other)
    {
        mc.LastUnlockedIndex = id;
        mc.timer = 0;
        gameObject.SetActive(false);
    }
}
