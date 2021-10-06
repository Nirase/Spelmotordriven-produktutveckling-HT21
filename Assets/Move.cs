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
    float score;

    private bool done;
    [SerializeField] private Material colourMaterial;

    [SerializeField] private float goalTime;
    private static readonly int ColorRemapRed = Shader.PropertyToID("colorRemapRED");

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
        if (done || Vector3.Distance(transform.position, player.transform.position) > 30)
            return;
        
        timer += Time.deltaTime * speed;
        float x = Mathf.Sin(timer) * size;

        if(x < 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                score += Time.deltaTime;
            }
            else
            {
                score -= Time.deltaTime;
            }

        }
        if(x > 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                score += Time.deltaTime;
            }
            else
            {
                score -= Time.deltaTime;
            }
        }
        if(x == 0)
        {
            if (!Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            {
                score += Time.deltaTime;
            }
            else
            {
                score -= Time.deltaTime;
            }
        }

        score = Mathf.Clamp(score, 0, 1);

        if (score >= 1)
        {
            done = true;
        }
        Debug.Log(score);

        colourMaterial.SetFloat("colorRemapRed", score);
        transform.position = startPos + new Vector3(x, 0, 0);
    }
}
