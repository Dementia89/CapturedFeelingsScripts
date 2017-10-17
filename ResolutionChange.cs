using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created by Jon

public class ResolutionChange : MonoBehaviour
{
    public Resolution[] res;
    public Dropdown dropdown;
    int count = 1;

    void Start()
    {
        res = Screen.resolutions;

        for (int i = 0; i < res.Length; i++)
        {
            if (i < res.Length - 1)
            {
                dropdown.options.Add(new Dropdown.OptionData());
            }
            dropdown.options[i].text = ResToString(res[i]);

            dropdown.value = i;

            dropdown.onValueChanged.AddListener(delegate
            {
                Screen.SetResolution(res[dropdown.value].width, res[dropdown.value].height, true);
            }); 
        }
    }

    string ResToString(Resolution res1)
    {
        return res1.width + " x " + res1.height;
    }
}