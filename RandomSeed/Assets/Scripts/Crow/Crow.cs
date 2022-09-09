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

    [SerializeField]
    private GameObject barrierefinlv;

    [Header("Coup de bec")]
    public BeakHite beaksHit;

    private Rigidbody2D rbBeaks;

    [SerializeField]
    private float cooldownMin =0f;
    [SerializeField]
    private float cooldownMax =10f;
    
    private float beaksHitTimer = 7;
    private bool beaksHitCanAttack = true;
    private bool beaksHitIsAttacking = false;
    private bool beaksHitIsFlyingAway = false;

    private float waitingTimeBeforeAttack = 2;
    private float waitingTimerBeforeAttack;
    private bool waitingBeforeAttack = false;

    [SerializeField]
    private float speed = 2;

    private Vector3 startingPos;
    private float elapsedTime;

    private FMOD.Studio.EventInstance instanceMusic;

    void Start()
    {
        rbBeaks = beaksHit.gameObject.GetComponent<Rigidbody2D>();

        startingPos = new Vector3(player.gameObject.transform.position.x, player.transform.position.y + 7, player.gameObject.transform.position.z);

        instanceMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Champ");
        //instanceMusic.start();
    }

    void Update()
    {
        if (inFight)
        {
            duration -= Time.deltaTime;
            if (duration < 0)
            {
                inFight = false;
                barrierefinlv.SetActive(false);

            }
                

            if(beaksHitCanAttack)
            {
                beaksHitCanAttack = false;
                beaksHitTimer = Random.Range(cooldownMin, cooldownMax);
                Debug.Log(beaksHitTimer);

                waitingBeforeAttack = true;
                startingPos = beaksHit.gameObject.transform.position;
            }
            else
            {
                beaksHitTimer -= Time.deltaTime;
                if(beaksHitTimer < 0)
                {
                    beaksHitCanAttack = true;
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SD/CorbeauStrike");
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
        if(collision.gameObject.CompareTag("Player") && !inFight)
        {
            inFight = true;
            instanceMusic.setParameterByName("Scene", 4.7f);
        }
    }

}
