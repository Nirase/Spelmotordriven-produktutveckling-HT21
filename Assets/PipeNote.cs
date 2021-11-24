using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNote : MonoBehaviour
{
    public bool triggered = false;
    [SerializeField] private NotePuzzle manager;
    private AudioSource sound;

    public bool puzzleComplete;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (puzzleComplete)
            return;
        
        manager.played.Add(this);
        sound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
