using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNote : MonoBehaviour
{
    public bool triggered = false;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) 
            return;
        
        triggered = true;
        sound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
