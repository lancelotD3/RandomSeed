using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    private float duration = 60f;
    private bool inFight = false;

    [SerializeField]
    private GameObject player;

    [Header("Coup de bec")]
    public BeakHite beaksHit;

    private Rigidbody2D rbBeaks;

    [SerializeField]
    private float beaksHitCooldown = 7;
    private float beaksHitTimer = 7;
    private bool beaksHitCanAttack = false;
    private bool beaksHitIsAttacking = false;
    private bool beaksHitIsFlyingAway = false;

    private float waitingTimeBeforeAttack = 2;
    private float waitingTimerBeforeAttack;
    private bool waitingBeforeAttack = false;

    [SerializeField]
    private float speed = 2;

    private Vector3 startingPos;
    private float elapsedTime;

    [Header("Coup de bec glissé")]
    public BeakHite beaksHitSlide;

    private Rigidbody2D rbBeaksSlide;

    private float startingSlideCooldown;
    private bool startingSlide = false;

    private float beaksHitTimerSlide = 7;
    private bool beaksHitCanAttackSlide = false;
    private bool beaksHitIsAttackingSlide = false;
    private bool beaksHitIsFlyingAwaySlide = false;

    private float waitingTimeBeforeAttackSlide = 2;
    private float waitingTimerBeforeAttackSlide;
    private bool waitingBeforeAttackSlide = false;

    private Vector3 startingPosSlidePreCharge;
    private float elapsedTimeSlidePreCharge;

    private Vector3 startingPosSlide;
    private float elapsedTimeSlide;

    void Start()
    {
        rbBeaks = beaksHit.gameObject.GetComponent<Rigidbody2D>();
        rbBeaksSlide = beaksHitSlide.gameObject.GetComponent<Rigidbody2D>();

        startingSlideCooldown = beaksHitCooldown;

        startingPos = new Vector3(player.gameObject.transform.position.x, player.transform.position.y + 7, player.gameObject.transform.position.z);
    }

    void Update()
    {
        if (inFight)
        {
            duration -= Time.deltaTime;
            if (duration < 0)
                inFight = false;

            if(beaksHitCanAttack)
            {
                beaksHitCanAttack = false;
                beaksHitTimer = beaksHitCooldown;

                waitingBeforeAttack = true;
                startingPos = beaksHit.gameObject.transform.position;
            }
            else
            {
                beaksHitTimer -= Time.deltaTime;
                if(beaksHitTimer < 0)
                {
                    beaksHitCanAttack = true;
                }

            }

            if(waitingBeforeAttack)
            {
                elapsedTime += Time.deltaTime;
                float pourcentageComplete = elapsedTime / waitingTimeBeforeAttack;
                beaksHit.gameObject.transform.position = Vector3.Lerp(startingPos, new Vector3(player.transform.position.x, player.transform.position.y + 7, player.transform.position.z), pourcentageComplete);
                waitingTimerBeforeAttack -= Time.deltaTime;
                if(waitingTimerBeforeAttack < 0)
                {
                    waitingTimerBeforeAttack = waitingTimeBeforeAttack;
                    waitingBeforeAttack = false;
                    beaksHitIsAttacking = true;
                    elapsedTime = 0;
                }
            }

            if(beaksHitIsAttacking)
            {
                BeaksAttack();
            }
            else if(beaksHitIsFlyingAway)
            {
                BeaksFlyAway();
            }


            ////////////////////////////////////////////////////////////////////////////////
            
            if(!startingSlide)
                startingSlideCooldown -= Time.deltaTime; if (startingSlideCooldown < 0) startingSlide = false;

            if(startingSlide)
            {
                if (beaksHitCanAttackSlide)
                {
                    beaksHitCanAttackSlide = false;
                    beaksHitTimerSlide = beaksHitCooldown;

                    waitingBeforeAttackSlide = true;
                    startingPosSlide = beaksHitSlide.gameObject.transform.position;
                }
                else
                {
                    beaksHitTimerSlide -= Time.deltaTime;
                    if (beaksHitTimerSlide < 0)
                    {
                        beaksHitCanAttackSlide = true;
                    }
                }


            }
        }
    }

    private void BeaksAttack()
    {
        rbBeaks.velocity = Vector3.zero;
        rbBeaks.velocity = new Vector2(rbBeaks.velocity.x, -speed);

        if (beaksHit.GetTouchGround())
        {
            beaksHit.SetTouchGround(false);
            beaksHitIsAttacking = false;
            beaksHitIsFlyingAway = true;
        } 
    }

    private void BeaksFlyAway()
    {
        rbBeaks.velocity = Vector3.zero;
        rbBeaks.velocity = new Vector2(rbBeaks.velocity.x, speed);

        if (beaksHitCanAttack)
            beaksHitIsFlyingAway = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inFight = true;
        }
    }
}
