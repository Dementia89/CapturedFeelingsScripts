using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public Light lightning;
    float flash;
    float thunder;
    bool power;
    int rate = 15;
    DateTime start;
    public static bool LightningActive = false;

    // Use this for initialization
    void Start()
    {
        lightning.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        thunder = UnityEngine.Random.Range(1, 1000);
        Flicker();

        if (Mathf.Abs(0 - thunder) <= rate)//if current and the random flicker are less than rate, change the bulb to be on/off
        {
            //Debug.Log("Thunder");
            power = true;
            lightning.GetComponent<Light>().enabled = true;
        }
        else
        {
            power = false;
            lightning.GetComponent<Light>().enabled = false;
        }

        if (LightningActive == false)
        {
            lightning.GetComponent<Light>().enabled = false;
            return;
        }
    }

    void Flicker()
    {
        flash = UnityEngine.Random.Range(1f, 10f);

        if (Mathf.Abs(0 - flash) <= 20)//if current and the random flicker are less than rate, change the bulb to be on/off
        {
            lightning.intensity = flash;

        }


    }
}
