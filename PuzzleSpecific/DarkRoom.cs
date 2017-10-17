using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoom : MonoBehaviour
{
    public GameObject PressurePlate;
    public Light[] Lamps;
    public GameObject Radio;
    public bool lightSwitch;


    // Use this for initialization
    void Start()
    {
        foreach(Light l in Lamps)
        {
            l.intensity = 0;
        }

        Radio.GetComponent<AudioSource>().mute = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        lightSwitch = PressurePlate.GetComponent<PressurePlates>().triggered;

        if (lightSwitch)
        {
            foreach (Light l in Lamps)
            {
                l.intensity = 1;
                
            }
            Radio.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            foreach (Light l in Lamps)
            {
                l.intensity = 0;
            }
            Radio.GetComponent<AudioSource>().mute = true;
        }
    }
}
