using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, 15, -10);
    }

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 15, -10);
    }
}
