using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNote : MonoBehaviour
{
    public bool triggered = false;
    [SerializeField] private NotePuzzle manager;
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
        
        
        manager.played.Add(this);
        triggered = true;
        sound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
