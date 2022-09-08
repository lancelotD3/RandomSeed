using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SD/UI Select");
        Application.Quit();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }
}
