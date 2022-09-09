using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFX : MonoBehaviour
{
    private SoundManagerUI soundManagerUI;
    private FMOD.Studio.Bus busFX;

    private Slider slider;

    private void Start()
    {
        soundManagerUI = GameObject.Find("SoundManagerUI").GetComponent<SoundManagerUI>();
        busFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        slider = GetComponent<Slider>();
    }

    bool firstLoop = false;
    private void Update()
    {
        if (!firstLoop)
        {
            firstLoop = true;
            slider.value = soundManagerUI.GetMusic();
        }
    }
    public void SetVolume(float volume)
    {
        busFX.setVolume(volume);
        soundManagerUI.SetSFX(volume);
    }
}
