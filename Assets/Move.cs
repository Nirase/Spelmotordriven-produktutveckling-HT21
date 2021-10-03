using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float timer;
    Vector3 startPos;
    [SerializeField]
    float speed;
    [SerializeField]
    float size;
    [SerializeField]
    Transform player;
    int score;
    void Start()
    {
        startPos = transform.position;
        score = 0;
    }
    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        timer += Time.deltaTime * speed;
        float x = Mathf.Sin(timer) * size;

        if(x < 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                score++;
            }
            else
            {
                score--;
            }

        }
        if(x > 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                score++;
            }
            else
            {
                score--;
            }
        }
        if(x == 0)
        {
            if (!Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            {
                score++;
            }
            else
            {
                score--;
            }
        }

        score = Mathf.Clamp(score, 0, 100000);
        Debug.Log(score);


        transform.position = startPos + new Vector3(x, 0, 0);
    }
}
