using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private CheckPointManager cpm;

    private void Start()
    {
        cpm = GameObject.FindObjectOfType<CheckPointManager>().GetComponent<CheckPointManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cpm.lastCheckPointPos = transform.position;
        }
    }
}
