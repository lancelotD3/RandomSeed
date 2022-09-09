using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundManagerUI : MonoBehaviour
{
    [SerializeField] private float soundSFXVolume = .5f;
    [SerializeField] private float soundMusicVolume = .5f;
    [SerializeField] private float soundAmbientVolume = .5f;
    public static SoundManagerUI Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    public float GetSFX() => soundSFXVolume;
    public float GetMusic() => soundMusicVolume;
    public float GetAmbient() => soundAmbientVolume;

    public void SetSFX(float value) => soundSFXVolume = value;
    public void SetMusic(float value) => soundMusicVolume = value;
    public void SetAmbient(float value) => soundAmbientVolume = value;
}
