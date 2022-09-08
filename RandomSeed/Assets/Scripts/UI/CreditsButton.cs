using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public GameObject credits;
    public GameObject menu;

    public void OpenMenu()
    {
        //FMODUnity.RuntimeManager.PlayOneShot("event:/SD/UI Select");
        credits.SetActive(false);
        menu.SetActive(true);

    }

    public void CloseMenu()
    {
        //FMODUnity.RuntimeManager.PlayOneShot("event:/SD/UI DeSelect");
        credits.SetActive(true);
        menu.SetActive(false);
    }
}
