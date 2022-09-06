using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    public void OpenCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
}
