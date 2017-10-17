using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created by Jon

public class SetVolume : MonoBehaviour {

    public Slider slider;
    public bool isMusic;

    void Start()
    {
        if (isMusic)
        {
            slider.value = PlayerPrefs.GetFloat("Music Volume");
        }
        else
        {
            slider.value = PlayerPrefs.GetFloat("FX Volume");
        }
    }
    
	void Update ()
    {
        if (isMusic)
        {
            PlayerPrefs.SetFloat("Music Volume", slider.value);
            //Debug.Log("Music Volume: " + PlayerPrefs.GetFloat("Music Volume"));
        }
        else
        {
            PlayerPrefs.SetFloat("FX Volume", slider.value);
            //Debug.Log("FX Volume: " + PlayerPrefs.GetFloat("FX Volume"));
        }

    }
}
