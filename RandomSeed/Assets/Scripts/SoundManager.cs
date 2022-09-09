using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager i;

    private FMOD.Studio.EventInstance instance;
    private FMOD.Studio.EventInstance instanceMarche;



    public PlayerMovement playermovement;

    private bool Walk = false;
    private int court;

    // Start is called before the first frame update
    void Start()
    {
        instanceMarche = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Champ");
        //instanceMarche.start();

    }

    private void Awake()
    {
        if (i != null && i != this)
            Destroy(gameObject);

        i = this;

        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        instanceMarche.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        instanceMarche.release();
        if (Input.GetAxisRaw("Horizontal") != 0f && playermovement.GetIsGrounded())
        {
            if (!Walk)
            {
                Walk = true;


                instance = FMODUnity.RuntimeManager.CreateInstance("event:/SD/Footspteps");
                instance.start();


                instanceMarche.setParameterByName("Marche", 1f);


                //Debug.Log("FS");

            }
        }
        else
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();

            instanceMarche.setParameterByName("Marche", 0f);

            Walk = false;
        }

        if (playermovement.GetIsRunning())
        {
            court = 1;
            instance.setParameterByName("court", court);
        }
        else
        {
            court = 0;
            instance.setParameterByName("court", court);
        }

        if (Input.GetButtonDown("Dash"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SD/Roulade");
        }

        if (Input.GetButtonDown("Jump") && playermovement.GetIsGrounded() && playermovement.GetIsRolling() == false) //&& playermovement.canJump)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SD/Jump");
        }
    }
}