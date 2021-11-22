using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthousePuzzle : MonoBehaviour
{
    List<BoxCollider> list;
    [SerializeField] Transform _lightHouse;
    [SerializeField] Transform _goal;
    [SerializeField] Flicker _light;
    [SerializeField] GameObject[] _fishes;

    int count = 1;
    int escortedFish = 0;
    bool partOne = false;
    bool partTwo = false;

    bool fishesActive = false;
    static float t = 0.0f;
    private float rotation = -25;

    Vector3 start;
    Vector3 end;

    void Start()
    {
        // For lerping the lighthouse position
        start = _lightHouse.transform.position;
        end = _lightHouse.transform.position + new Vector3(0, 10, 0);

        //For deactivating fishes untill part two
        foreach(var gameObject in _fishes)
            gameObject.SetActive(false);

        // Initialization for pattern detection when ice skating around lighthouse. + 1 for the fish detection..
        list = new List<BoxCollider>();
        foreach (var i in gameObject.GetComponentsInChildren<BoxCollider>())
            list.Add(i);
    }

    void Update()
    {   
        if(count == list.Count && !partOne)
            partOne = true;

        if(partOne && !partTwo)
        {
            ElevateLighthouse();
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

    public void Add()
    {
        count++;
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
        _lightHouse.transform.position = Vector3.Lerp(start, end, t);
        t += 0.5f * Time.deltaTime;

        if(_lightHouse.position != end)
            _lightHouse.RotateAround(_lightHouse.transform.position, Vector3.up, rotation * Time.deltaTime);
    }
}
