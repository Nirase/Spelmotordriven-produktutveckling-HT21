using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class Flicker : MonoBehaviour
{

    [SerializeField] GameObject lighthouseTheme;
    FMODUnity.StudioEventEmitter emitter;
    private string param = "";

    Light lightComp;
    float m_Value;

    public float minimum = -1.0F;
    public float maximum =  1.0F;

    // starting value for the Lerp
    static float t = 0.0f;
    public bool flicker = true;

    private float sMin = 0.0f;
    private float sMax = 1.0f;
    private float sLerp = 0.0f;

    void Start()
    {
        lightComp = GetComponent<Light>();
        m_Value = lightComp.intensity;
        emitter = lighthouseTheme.GetComponent<FMODUnity.StudioEventEmitter>();
        param = emitter.Params[0].Name;
    }

    void Update()
    {
            if(flicker)
            {
                lightComp.intensity = Mathf.Lerp(minimum, maximum, t) * m_Value;
                emitter.SetParameter(param, Mathf.Lerp(sMin, sMax, t));
                t += 0.5f * Time.deltaTime;

                if (t > 1.0f)
                {
                    float temp = maximum;
                    maximum = minimum;
                    minimum = temp;

                    // Swap sound lerp
                    float stemp = sMax;
                    sMax = sMin;
                    sMin = stemp;

                    t = 0.0f;
                }
            }
            else
            {
                lightComp.intensity = m_Value;
                emitter.SetParameter(param, 1.0f);
            }
  
    }
}
