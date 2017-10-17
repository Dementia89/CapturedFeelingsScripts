using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Dan
//Modified by: Anthony

public class CageLight : MonoBehaviour
{

    public Light LightObject;//cage light
    public GameObject Plate;//pressure plate that activates light
    public bool lightOn;

    void Start()
    {
        LightObject.intensity = 0;
        lightOn = false;

    }

    private void Update()
    {

        if (Plate.GetComponent<PressurePlates>().triggered == true)
        {
            Unlock();
        }

        //if (Plate.GetComponent<PressurePlateCustom>().triggered == true)
        //{
        //    Unlock();
        //}

        if (Plate.GetComponent<PressurePlates>().triggered == false)
        {
            Lock();
        }

    }

    private void Unlock()
    {
        LightObject.intensity = 2;
        lightOn = true;
    }

    private void Lock()
    {
        LightObject.intensity = 0;
        lightOn = false;
    }
}
