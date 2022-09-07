using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakHite : MonoBehaviour
{
    private bool touchGround = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            SetTouchGround(true);
        }
    }

    public bool GetTouchGround() => touchGround;
    public void SetTouchGround(bool value) => touchGround = value;
}
