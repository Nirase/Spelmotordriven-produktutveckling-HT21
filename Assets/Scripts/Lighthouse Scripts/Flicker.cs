using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class Flicker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject lighthouseTheme;
    [SerializeField] Light spotLight;

    [Header("Settings")]
    [SerializeField] float frequency = 1;
    public bool flicker = true;

    Light lightComp;
    float maxLightIntensity;
    float maxLightConeOpacity;
    Renderer renderer;

    FMODUnity.StudioEventEmitter emitter;
    string param = "";
    float sMin = 0.0f;
    float sMax = 1.0f;

    void Start()
    {
        lightComp = spotLight.GetComponent<Light>();
        maxLightIntensity = lightComp.intensity;
        renderer = GetComponent<Renderer>();
        maxLightConeOpacity = renderer.material.GetFloat("_Opacity");

        emitter = lighthouseTheme.GetComponent<FMODUnity.StudioEventEmitter>();
        param = emitter.Params[0].Name;
    }

    void Update()
    {
        if (flicker)
        {
            float strength = Mathf.Clamp(Mathf.Sin(Time.time * frequency), 0, Mathf.Infinity);

            lightComp.intensity = maxLightIntensity * strength;
            renderer.material.SetFloat("_Opacity", maxLightConeOpacity * strength);

            emitter.SetParameter(param, Mathf.Lerp(sMin, sMax, strength));
        }
        else
        {
            lightComp.intensity = maxLightIntensity;
            renderer.material.SetFloat("_Opacity", maxLightConeOpacity);
            emitter.SetParameter(param, 1.0f);
        }
    }
}
