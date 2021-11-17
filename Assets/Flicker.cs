using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    Light lightComp;
    float m_Value;

    public float minimum = -1.0F;
    public float maximum =  1.0F;

    // starting value for the Lerp
    static float t = 0.0f;

    void Start()
    {
        lightComp = GetComponent<Light>();
        m_Value = lightComp.intensity;
    }

    void Update()
    {
        lightComp.intensity = Mathf.Lerp(minimum, maximum, t) * m_Value;
        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
