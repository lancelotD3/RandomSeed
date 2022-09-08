using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    public void OpenCredits()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SD/UI Select");
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SD/UI DeSelect");
        menu.SetActive(true);
        credits.SetActive(false);
    }
}
