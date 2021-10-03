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
