using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    public GameObject player;

    public Transform spawnPos;

    bool doOnce;
    private void Update()
    {
        if(doOnce)
        {
            player.transform.position = spawnPos.position;
            doOnce = false;
        }

    }
}
