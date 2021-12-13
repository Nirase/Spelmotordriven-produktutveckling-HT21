using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    private bool stateOne = true;
    private bool stateTwo = false;

    [SerializeField] private string stateNameOne;
    [SerializeField] private string stateNameTwo;

    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        if (!stateOne) 
            return;
        animator.Play(stateNameOne);
        stateOne = false;
        stateTwo = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (!stateTwo) 
            return;
        animator.Play(stateNameTwo);
        stateOne = true;
        stateTwo = false;
    }
}
