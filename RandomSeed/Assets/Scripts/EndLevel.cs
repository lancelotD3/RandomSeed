using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public LevelChanger levelChanger;
    public CheckPointManager checkPointManager;
    
    public string nextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (nextScene == "LD_Forêt")
            {
                checkPointManager.lastCheckPointPos = new Vector2(242.07f, -85.28999f);
                Debug.Log("salu");
            }
            levelChanger.FadeToLevel(nextScene);
        }
    }
}
