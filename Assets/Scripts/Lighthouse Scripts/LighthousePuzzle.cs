using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthousePuzzle : MonoBehaviour
{
    [SerializeField] Transform _lightHouse;

    [SerializeField] Transform _player;
    private Vector3 origo;
    [SerializeField] Transform _goal;
    [SerializeField] Flicker _light;
    [SerializeField] GameObject[] _fishes;
    float count = 0;
    int escortedFish = 0;
    bool partOne = false;
    bool partTwo = false;
    bool fishesActive = false;
    bool isRaising = false;
    private float t = 0.0f;
    [SerializeField, Range(0, 1)] float tpain = 0.25f;
    [SerializeField, Range(-25, 25)] float rotation = -25;
    [SerializeField, Range(1, 10)] float MaxTimer = 3f;
    [SerializeField, Range(0, 1)] float countStep;
    private float timer = 0f;
    Vector3 start;
    Vector3 end;
    Vector3 partialEnd;

    void Start()
    {
        // For lerping the lighthouse position
        start = _lightHouse.transform.position;
        end = _lightHouse.transform.position + new Vector3(0, 10, 0);
        
        origo = _lightHouse.transform.position;
        origo.y = 0;

        //For deactivating fishes untill part two
        foreach(var gameObject in _fishes)
            gameObject.SetActive(false);
    }

    void Update()
    {   
        // When first arriving to lighthouse, unscrew it from ice.
        if(!partOne)
        {
            if(count <= 0)
                count = 0;

            timer += Time.deltaTime;
            partialEnd = start + new Vector3(0, count * countStep, 0);
            
            if(timer > MaxTimer)
            {
                count--;
                timer = 0;
                t = 0;
            }
            if(_lightHouse.position != end)
            {
                ElevateLighthouse();
            }
        }
     
        // End first phase.
        if(_lightHouse.position.y >= end.y && !partOne)
            partOne = true;

        if(partOne && !partTwo)
        {
            if(!fishesActive)
                ActivateFishes();
            
            if(escortedFish >= _fishes.Length)
                partTwo = true;
        }

        if(partTwo)
        {
            _light.flicker = false;
            // dissipate storm..
        }

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "EscortFish")
            escortedFish++;
    }

    public void Add(BoxCollider col)
    {
        count++;
        timer = 0; // Not going down timer.
        t = 0;  // Lerp.

        // Comp geometry - Left / Rigth turn testing
        var a = col.transform.position;
        a.y = 0; 

        var u = origo - a;

        var temp = _player.transform.position;
        temp.y = 0;

        var w = temp - a;

        if (( (u.x * w.y) - (u.y*w.x) ) > 0)
            Debug.Log("Left Turn");
        else
        {
            Debug.Log("Right Turn");
        }
    }

    private void ActivateFishes()
    {
        fishesActive = true;
        foreach(var gameObject in _fishes)
        {
            if(gameObject.activeSelf == false)
                gameObject.SetActive(true);
        }
    }

    private void ElevateLighthouse()
    {   

        if(_lightHouse.position != partialEnd)
        {   
            float rotFactor;
            if(_lightHouse.transform.position.y > partialEnd.y)
                rotFactor = 1;
            else
                rotFactor = -1;

            _lightHouse.transform.position = Vector3.Lerp(_lightHouse.transform.position, partialEnd, t);
            t += tpain * Time.deltaTime;

            _lightHouse.RotateAround(_lightHouse.transform.position, Vector3.up, rotation * rotFactor * Time.deltaTime);
        }

    }
}
