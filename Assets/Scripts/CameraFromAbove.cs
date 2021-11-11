using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFromAbove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    Vector3 offsetY = new Vector3(0, 15, 0);
    void Start()
    {
        transform.position = player.transform.position + offsetY;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offsetY;
    }
}
