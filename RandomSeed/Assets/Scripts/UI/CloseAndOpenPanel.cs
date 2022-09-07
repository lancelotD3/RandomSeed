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
        PanelToOpen.SetActive(false);
        PanelToClose.SetActive(true);
    }

    public void CloseMenu()
    {
        PanelToOpen.SetActive(true);
        PanelToClose.SetActive(false);
    }
}
