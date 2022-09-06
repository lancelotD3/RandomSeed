using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public GameObject credits;
    public GameObject menu;

    public void OpenMenu()
    {
        credits.SetActive(false);
        menu.SetActive(true);

    }

    public void CloseMenu()
    {
        credits.SetActive(true);
        menu.SetActive(false);
    }
}
