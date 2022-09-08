using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropSpawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject waterDrop;
    [SerializeField]
    private float cooldown = 3;
    private float timer = 3;
    private bool canSpawn = false;

    private void Start()
    {
        timer = cooldown;
    }

    private void Update()
    {
        if(canSpawn)
        {
            Instantiate(waterDrop, spawnPos);
            canSpawn = false;
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer<0)
            {
                canSpawn = true;
                timer = cooldown;
            }
        }
    }
}
