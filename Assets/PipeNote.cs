using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNote : MonoBehaviour
{
    public bool triggered = false;
    [SerializeField] private NotePuzzle manager;
    private AudioSource sound;
    [SerializeField] private Flock flock;
    public bool puzzleComplete;

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
        
        // Scatter
        StartCoroutine(Scatter());
     

        // Light

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Scatter()
    {
        flock.boundsDistance = 20;
        yield return new WaitForSeconds(3f);
        flock.boundsDistance = 8;
    }
}
