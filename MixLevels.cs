using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Created by Jon

public class MixLevels : MonoBehaviour
{

    public AudioMixer mixer;

    public void setMusicVolume(float musicLvl)
    {
        musicLvl = PlayerPrefs.GetFloat("Music Volume");
        mixer.SetFloat("musicVol", musicLvl);
    }
    public void setSFXVolume(float sfxLvl)
    {
        sfxLvl = PlayerPrefs.GetFloat("FX Volume");
        mixer.SetFloat("sfxVol", sfxLvl);
    }
}
