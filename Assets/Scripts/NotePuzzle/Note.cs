using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public bool triggered = false;
    [SerializeField] private NotePuzzle manager;
    //private AudioSource sound;
    [SerializeField] public string note; 
    public bool puzzleComplete;

    // Boids related
    [SerializeField] private Flock flock;
    FlockUnit[] boids;

    // Glow
    bool glow = false;
    bool one = true;
    bool two = false;
    private float factor = 50.0f;
    private float lerpt = 0.0f;
    Color baseColor;
    Color glowColor;
    Color lerpColor;

    void Start()
    {
        //sound = GetComponent<AudioSource>();
        boids = flock.allUnits;
        baseColor = boids[0].GetComponentInChildren<MeshRenderer>().material.GetColor("Glow_");
        glowColor = new Color(baseColor.r * factor, baseColor.g * factor, baseColor.b * factor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (puzzleComplete)
            return;
        
        NoteEvents.current.NotePlayed(this);
        //sound.Play();
        
        // Scatter
        StartCoroutine(Scatter());
     
        // Light


    }

    void Update()
    {
        if(glow)
            Glow();
       
    }

    private IEnumerator Scatter()
    {
        glow = true;
        flock.boundsDistance = 20;
        yield return new WaitForSeconds(3f);
        flock.boundsDistance = 8;
    }

    private void Glow()
    {
        // This works, dont mess with it just roll with it...

        // First pass
        if(one)
        {
            lerpt += (float)0.5 * Time.deltaTime;
            if(lerpt > 1)
            {
                one = false;
                two = true;
            }
        }
        
        // Second pass
        if(two && !one)
        {
            lerpt -= (float)0.5 * Time.deltaTime;
            if(lerpColor == baseColor)
                two = false;
        }
        
        // End lerp after A -> B -> A
        if(!one && !two)
        {
            glow = false;
            one = true;
            two = false;
        }

        lerpColor = Color.Lerp(baseColor, glowColor, /*Mathf.PingPong(Time.time, 1)*/ lerpt);
        foreach(var boid in boids)
            boid.Glow(lerpColor); 
    }
}
