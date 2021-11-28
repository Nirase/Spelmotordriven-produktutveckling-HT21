using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class AudioManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string GameplayEvent = "";
    [FMODUnity.EventRef]
    public string FishEvent = "";
    [FMODUnity.EventRef]
    public string FactoryEvent = "";

    FMOD.Studio.EventInstance playerState;

    FMOD.Studio.PARAMETER_ID factoryParameterId;


    // Start is called before the first frame update
    void Start()
    {
        FMOD.Studio.EventDescription factoryEventDescription;
        playerState.getDescription(out factoryEventDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION factoryParameterDescription;
        factoryEventDescription.getParameterDescriptionByName("Factory", out factoryParameterDescription);
        factoryParameterId = factoryParameterDescription.id;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        playerState.release();
    }
}
