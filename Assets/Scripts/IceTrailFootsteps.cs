using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrailFootsteps : MonoBehaviour
{
   
    ParticleSystem ps;
    private Gradient gradient = new Gradient();
    public bool swapColors = true;

    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        var main = ps.main;
    }

    // Update is called once per frame
    void Update()
    {
        var trails = ps.trails;
         

        if(swapColors)
        {
                gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.blue, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) } );

        }
        else
        {
                gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.black, 0.0f), new GradientColorKey(Color.blue, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(0.0f, 0.0f) } );
        }


        trails.colorOverLifetime = gradient;

    }
    
    private void OnTriggerEnter(Collider other) 
    {
        swapColors = true;

    }
    private void OnTriggerExit(Collider other) 
    {
        swapColors = false;
    }


}
