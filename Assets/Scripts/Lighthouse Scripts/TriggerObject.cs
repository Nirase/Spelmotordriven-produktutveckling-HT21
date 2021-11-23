using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    LighthousePuzzle _parent;
    void Start() {
        _parent = GetComponentInParent<LighthousePuzzle>();
    }
    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            _parent.Add(GetComponent<BoxCollider>());
        }
    }
}
