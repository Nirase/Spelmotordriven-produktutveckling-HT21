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
    private float value = 100f;

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
