using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckPointSystem : MonoBehaviour
{
    private CheckPointManager cpm;
    private void Start()
    {
        cpm = GameObject.FindObjectOfType<CheckPointManager>().GetComponent<CheckPointManager>();
        transform.position = cpm.lastCheckPointPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Damage"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
