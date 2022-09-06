using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private float RuningSpeed = 4;

    [SerializeField]
    private float jumpingForce = 6;

    private float horizontal;
    private bool isFacingRight = true;
    private bool jump = false;
    private bool crouch = false;

    [SerializeField]
    private float dashDistance = 15f;
    private bool dash = false;
    private bool isDashing = false;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private BoxCollider2D boxCollider;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded() && dash == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
        }

        Flip();
        
        if (Input.GetButtonDown("Dash") && IsGrounded() && horizontal != 0)
        {
            dash = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(dash)
        {
            StartCoroutine(Dash(horizontal));
            dash = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    IEnumerator Dash(float direction)
    {
        isDashing = true;
        boxCollider.enabled = false;
        speed *= 3;
        yield return new WaitForSeconds(0.4f);
        speed /= 3;
        isDashing = false;
        boxCollider.enabled = true;
    }
}
