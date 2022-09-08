using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector3 gap = gameObject.transform.position - collision.gameObject.transform.position;
            if (gap.x > 0)
                collision.gameObject.GetComponent<PlayerMovement>().AddForce(new Vector2(-300, 300));
            else
                collision.gameObject.GetComponent<PlayerMovement>().AddForce(new Vector2(300, 300));
        }
    }
}