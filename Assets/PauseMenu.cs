using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{


    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
