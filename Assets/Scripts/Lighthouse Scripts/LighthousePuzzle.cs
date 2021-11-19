using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthousePuzzle : MonoBehaviour
{
    List<BoxCollider> list;
    [SerializeField] Transform _lightHouse;
    int count = 0;
    bool partOne = false;
    static float t = 0.0f;
    private float rotation = -25;

    Vector3 start;
    Vector3 end;

    void Start()
    {
        start = _lightHouse.transform.position;
        end = _lightHouse.transform.position + new Vector3(0, 10, 0);

        list = new List<BoxCollider>();
        foreach (var i in gameObject.GetComponentsInChildren<BoxCollider>())
            list.Add(i);
        Debug.Log(list.Count);
    }

    // Update is called once per frame
    void Update()
    {   
        if(count == list.Count && !partOne)
            partOne = true;

        if(partOne)
            ElevateLighthouse();

    }

    public void Add()
    {
        count++;
    }

    private void ElevateLighthouse()
    {   
        _lightHouse.transform.position = Vector3.Lerp(start, end, t);
        t += 0.5f * Time.deltaTime;

        if(_lightHouse.position != end)
            _lightHouse.RotateAround(_lightHouse.transform.position, Vector3.up, rotation * Time.deltaTime);
    }
}
