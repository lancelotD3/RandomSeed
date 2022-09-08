using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAndOpenPanel : MonoBehaviour
{
    public GameObject PanelToOpen;
    public GameObject PanelToClose;
    public bool fade = true;

    public void OpenMenu()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SD/UI Select");
        PanelToOpen.SetActive(false);
        PanelToClose.SetActive(true);
    }

    public void CloseMenu()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SD/UI DeSelect");
        PanelToOpen.SetActive(true);
        PanelToClose.SetActive(false);
    }
}
