using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEvents : MonoBehaviour
{
    public static NoteEvents current;
    // Start is called before the first frame update
    private void Awake()
    {
        current = this;
    }

    public event Action<Note> onNotePlayed;

    public void NotePlayed(Note note)
    {
        onNotePlayed?.Invoke(note);
    }


}
