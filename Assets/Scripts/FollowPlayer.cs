using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    //Camera cam;
    //Vector3 offSetY = new Vector3(0, 15, 0);

    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, 15, -10);
        //cam = GetComponent<Camera>();
    }

    void Update()
    {
        //Vector3 behind = player.position -player.transform.forward * 10 + offSetY;
        transform.position = player.transform.position + new Vector3(0, 15, -10);

        //cam.transform.position = Vector3.Lerp(cam.transform.position, behind, 1);
        //Vector3 fw = player.position - cam.transform.position;
        //cam.transform.forward = fw;

    }
}
