using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audioSources[0].Play();

            audioSources[1].Pause();
            audioSources[2].Pause();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioSources[1].Play();

            audioSources[0].Pause();
            audioSources[2].Pause();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audioSources[2].Play();

            audioSources[0].Pause();
            audioSources[1].Pause();
        }
    }
}
