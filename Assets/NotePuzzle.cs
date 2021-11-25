using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePuzzle : MonoBehaviour
{

    public List<PipeNote> played;
    private bool puzzleCompleted = false;
    [SerializeField] private PipeNote[] pipes;

    void Start()
    {

    }

    void RestartPuzzle()
    {
        played.Clear();
        for (int i = 0; i < pipes.Length; ++i)
            pipes[i].puzzleComplete = false;
    }

    void Update()
    {
        if (played.Count != pipes.Length) return;


        for (var i = 0; i < played.Count; ++i)
        {
            pipes[i].puzzleComplete = true;
            if (played[i] != pipes[i])
            {
                RestartPuzzle();
                return;
            }
        }

        puzzleCompleted = true;
        Debug.Log("complete");
    }
}
