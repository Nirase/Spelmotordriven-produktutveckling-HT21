using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleColliders : MonoBehaviour
{
    [SerializeField]
    GameObject[] points;

    public float timer = 0;
    [SerializeField]
    float maxTimer;

    [SerializeField]
    int lastUnlockedIndex;

    [SerializeField]
    Material colorCube;
    bool activated = false;


    IEnumerator fadeColors()
    {
        float val = 0.1f;
        activated = true;

        Debug.Log("Hello from coroutine");
        while(colorCube.GetFloat("cyan") < 1)
        {
            colorCube.SetFloat("cyan", val);
            val += 0.05f;
            yield return new WaitForSeconds(0.1f); 
        }

    }

    public int LastUnlockedIndex 
    { 
        get => lastUnlockedIndex;
        set { if (Mathf.Abs(lastUnlockedIndex - value) <= 1 || lastUnlockedIndex == 0)
                lastUnlockedIndex = value;
            else
            {
                foreach (GameObject item in points)
                {
                    if (item.activeSelf == false)
                    {
                        item.SetActive(true);
                    }
                }
                lastUnlockedIndex = 0;
            }
        } 
    }

    void Start()
    {
        colorCube.SetFloat("cyan", 0f);

        int i = 1;
        foreach (GameObject point in points)
        {
            point.GetComponent<ColliderDetection>().id = i;
            i++;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer < maxTimer)
        {
            foreach (GameObject item in points)
            {
                if(item.activeSelf == true)
                {
                    return;
                }
            }
            Debug.Log("Pattern Followed");
            
            if(!activated)
                StartCoroutine(fadeColors());
        }
        else
        {
            foreach (GameObject item in points)
            {
                if (item.activeSelf == false)
                {
                    item.SetActive(true);
                }
            }
        }
    }
}
