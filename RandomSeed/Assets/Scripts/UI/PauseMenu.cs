using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PauseMenu : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    //private FMOD.Studio.Bus busSFX;
    //private FMOD.Studio.Bus busMusic;
    //private FMOD.Studio.Bus busAmbiance;


    private static bool gameIsPause = false;

    public GameObject PauseMenuUI;

    private void Start()
    {
        //FMOD
        FMODUnity.RuntimeManager.CreateInstance("snapshot:/Pause");

        Resume();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if(gameIsPause)
            {
                instance.setParameterByName("Pause", 0f);   //FMOD
                Resume();
            }
            else
            {
                instance.setParameterByName("Pause", 1f);   //FMOD
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        SetGameIsPause(false);
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        SetGameIsPause(true);
    }

    public static void SetGameIsPause(bool value) => gameIsPause = value;
    public static bool GetGameIsPause(bool value) => gameIsPause;
}
