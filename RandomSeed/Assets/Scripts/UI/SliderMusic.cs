using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusic : MonoBehaviour
{
    private SoundManagerUI soundManagerUI;
    private FMOD.Studio.Bus busMusic;

    private Slider slider;

    private void Start()
    {
        soundManagerUI = GameObject.Find("SoundManagerUI").GetComponent<SoundManagerUI>();
        busMusic = FMODUnity.RuntimeManager.GetBus("bus:/Musique");
        slider = GetComponent<Slider>();
    }

    bool firstLoop = false;
    private void Update()
    {
        if(!firstLoop)
        {
            firstLoop = true;
            slider.value = soundManagerUI.GetMusic();
        }
    }

    public void SetVolume(float volume)
    {
        busMusic.setVolume(volume);
        soundManagerUI.SetMusic(volume);
    }
}
