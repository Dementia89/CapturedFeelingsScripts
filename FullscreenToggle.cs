using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created by Jon

public class FullscreenToggle : MonoBehaviour {

    public Toggle toggle;

	void Update ()
    {
        if(toggle.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }	
	}
}
