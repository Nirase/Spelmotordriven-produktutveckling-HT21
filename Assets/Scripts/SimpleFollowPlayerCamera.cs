using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, 15, -5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 15, -5);
    }
}
