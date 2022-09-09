using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMBATMUSIQEU : MonoBehaviour
{
    private bool doOnce = false;

    private FMOD.Studio.EventInstance instanceMusiqueChamp;
    private FMOD.Studio.EventInstance instanceMusiqueCombat;

    public PlayerMovement Player;
    private float Mort = 1.5f;

    void Start()
    {

        instanceMusiqueChamp = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Champ");
        instanceMusiqueChamp.start();
        instanceMusiqueCombat = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Combat");
        //instanceMusiqueCombat.start();
    }

    private void Update()
    {
        if (Player.GetIsDead())
        {
            instanceMusiqueCombat.setParameterByName("Mort", Mort);
            Debug.Log("jhgsef");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Player") && !doOnce)
        {
            doOnce = !doOnce;
            instanceMusiqueChamp.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instanceMusiqueChamp.release();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Music/Combat");
        }
    }
}
