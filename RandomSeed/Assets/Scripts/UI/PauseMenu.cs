using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private static bool gameIsPause = false;

    public GameObject PauseMenuUI;

    private void Start()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if(gameIsPause)
            {
                Resume();
            }
            else
            {
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
