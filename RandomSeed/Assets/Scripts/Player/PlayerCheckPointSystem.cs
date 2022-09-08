using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckPointSystem : MonoBehaviour
{
    private CheckPointManager cpm;

    public GameObject panel;
    private bool spawnPanel = false;

    private PlayerMovement playerMovement;

    private float delay = 6f;
    private void Start()
    {
        cpm = GameObject.FindObjectOfType<CheckPointManager>().GetComponent<CheckPointManager>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        transform.position = cpm.lastCheckPointPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Damage"))
        {
            if (!spawnPanel)
            {
                panel.SetActive(true);
                playerMovement.SetIsDead(true);
                spawnPanel = true;
            }
        }
    }

    private void Update()
    {
        if (spawnPanel)
        {
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
