using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAmbient : MonoBehaviour
{
    private SoundManagerUI soundManagerUI;
    private FMOD.Studio.Bus busAmbient;

    private Slider slider;

    private void Start()
    {
        soundManagerUI = GameObject.Find("SoundManagerUI").GetComponent<SoundManagerUI>();
        busAmbient = FMODUnity.RuntimeManager.GetBus("bus:/Ambiance");
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
        busAmbient.setVolume(volume);
        soundManagerUI.SetAmbient(volume);
    }
}
