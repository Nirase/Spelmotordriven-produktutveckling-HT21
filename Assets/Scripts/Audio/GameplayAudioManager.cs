using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

public class GameplayAudioManager : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    FMODUnity.StudioEventEmitter emitter;
    private string param = "";
    [SerializeField, Range(0, 100)] private float value;

    void Start()
    {
       emitter = GetComponent<FMODUnity.StudioEventEmitter>();
       param = emitter.Params[2].Name; // Kinda hacky but works.
    }

    void Update()
    {
        if(rb.velocity.magnitude > 5f)
        {
            emitter.SetParameter(param, value);
        }
        else
        {
            emitter.SetParameter(param, 0);
        }
    }
    
}
