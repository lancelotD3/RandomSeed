using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAnimSlide : MonoBehaviour
{
    public Animator animator;
    private Crow crow;

    void Start()
    {
        crow = gameObject.GetComponentInParent<Crow>();
    }

    private void Update()
    {
        animator.SetBool("Attack", crow.GetStartingSlide());
    }
}
