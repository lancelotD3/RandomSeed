using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endlevel1 : MonoBehaviour
{
    public LevelChanger levelChanger;
    private void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            levelChanger.FadeToLevel("MainMenu");
        }
    }
}
