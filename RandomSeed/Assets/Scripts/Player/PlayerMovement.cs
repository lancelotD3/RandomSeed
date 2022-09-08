using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private float runingSpeed = 4;

    private bool isRunnig = false;
    private bool isWalking = false;

    [SerializeField]
    private float jumpingForce = 6;

    private float horizontal;
    private bool isFacingRight = true;

    [SerializeField]
    private float dashCooldown = 2f;
    private float dashTimer = 0f;
    private bool canDash = true;

    [SerializeField]
    private float dashSpeed = 8f;

    [SerializeField]
    private float dashTime = 0.4f;

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

    private float initialSpeed;

    private bool isDead = false;
    private void Start()
    {
        initialSpeed = speed;    
    }

    void Update()
    {
        if(!isDead)
        {

        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
            isWalking = true;
        else
            isWalking = false;

        if(Input.GetButtonDown("Jump") && IsGrounded() && dash == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
        }

        Flip();
        
        if (Input.GetButtonDown("Dash") && IsGrounded() && horizontal != 0 && canDash)
        {
            dash = true;
            canDash = false;
        }
        else if (!canDash)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer < 0)
            {
                canDash = true;
                dashTimer = dashCooldown;
            }
        }

        if(Input.GetButton("Run") && IsGrounded() && !isDashing)
        {
            isRunnig = true;
            speed = runingSpeed;
        }
        else if (!isDashing)
        {
            isRunnig = false;
            speed = initialSpeed;
        }
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
        speed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        speed = initialSpeed;
        isDashing = false;
        boxCollider.enabled = true;
    }

    public bool GetIsRunning() => isRunnig;
    public bool GetIsWalking() => isWalking;
    public bool GetIsRolling() => isDashing;
    public bool GetIsGrounded() => IsGrounded();
    public float GetY() => rb.velocity.y;
    public bool GetIsDead() => isDead;
    public void SetIsDead(bool value) => isDead = value;

}
