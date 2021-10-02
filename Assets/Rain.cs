using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public ParticleSystem part;
    public GameObject splash;
    public List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player")) return;
        part.GetCollisionEvents(other, collisionEvents);
        var splashEffect = Instantiate(splash, collisionEvents[0].intersection, Quaternion.identity);
        splashEffect.GetComponent<ParticleSystem>().Play();
        
    }
}
