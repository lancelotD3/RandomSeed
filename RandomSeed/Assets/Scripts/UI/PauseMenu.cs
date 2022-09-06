using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private static bool gameIsPause = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
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

    private void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        SetGameIsPause(false);
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        SetGameIsPause(true);
    }

    public static void SetGameIsPause(bool value) => gameIsPause = value;
    public static bool GetGameIsPause(bool value) => gameIsPause;
}
