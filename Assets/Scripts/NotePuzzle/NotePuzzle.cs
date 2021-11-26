using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NotePuzzle : MonoBehaviour
{
    private int currentIndex = 0;
    private bool puzzleCompleted = false;
    [FormerlySerializedAs("pipes")] [SerializeField] private string[] notes;

    void Start()
    {
        NoteEvents.current.onNotePlayed += NotePlayed;
    }

    void NotePlayed(Note note)
    {
        if (note.note != notes[currentIndex])
            currentIndex = 0;
        else
            currentIndex++;
        
        
        if (currentIndex == notes.Length)
        {
            puzzleCompleted = true;
        }
    }

    void Update()
    {
        if (!puzzleCompleted) return;
        Debug.Log("complete");
    }
}
