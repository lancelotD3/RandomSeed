using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMusiqueField : MonoBehaviour
{
    private bool doOnce = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !doOnce)
        {
            doOnce = true;

        }
    }
}
