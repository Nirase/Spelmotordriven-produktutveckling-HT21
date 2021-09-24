using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] PlayableCharacters;
    int count = 0;
    [SerializeField]
    GameObject[] textMeshes;

    [SerializeField]

    void Start()
    {
        for (int i = 0; i < PlayableCharacters.Length; i++) 
        {
            PlayableCharacters[i].SetActive(false);
            textMeshes[i].SetActive(false);
        }
        PlayableCharacters[count].SetActive(true);
        textMeshes[count].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayableCharacters[count].SetActive(false);
            textMeshes[count].SetActive(false);
            count++;
            if (count >= PlayableCharacters.Length)
                count = 0;
            PlayableCharacters[count].SetActive(true);
            textMeshes[count].SetActive(true);
        }
    }
}
