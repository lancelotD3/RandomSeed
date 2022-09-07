using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator animator;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsRunning", playerMovement.GetIsRunning());
        animator.SetBool("IsWalking", playerMovement.GetIsWalking());
        animator.SetBool("IsRolling", playerMovement.GetIsRolling());
        animator.SetBool("IsGrounded", playerMovement.GetIsGrounded());
        animator.SetFloat("Y", playerMovement.GetY());
    }
}
