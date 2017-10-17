using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public Light[] bulbs = new Light[1];
    public Color lightColor;
    public float intensity = 1;
    public bool power = true;
    public bool flickerEffect = true;
    Light flickerBulb;
    int fb;//to randomly select a bulb from the array to flicker
    
    int flicker;
    int current = 0;
    public int rate = 10;
    bool hadFlicker;

    

    //TODO: Change the emission material to match the light flicker
    Material em; //emission material of the light

    public bool happy;

    // Use this for initialization
    void Start()
    {
        
        if (bulbs.Length > 1)
        {
            fb = Random.Range(1, bulbs.Length);//Randomly selects a light to flicker out of the array of lights
            flickerBulb = bulbs[fb];
        }
        else
        {
            flickerBulb = bulbs[0];//if there is only one light in the array, select that light to flicker
        }
        foreach(Light l in bulbs)
        {
            l.color = lightColor;
            l.intensity = intensity;
        }

        if (power == true)//turns bulb on and off
        {
            flickerBulb.intensity = 1;
        }
        else
        {
            flickerBulb.intensity = 0;
        }

        em = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flickerEffect == false) return;//do not use the flicker effect

        if (happy == true)
        {
            flickerEffect = false;
            
            return;

        }

        Flicker();


    }

    void Flicker()
    {
        flicker = Random.Range(1, 100);

        if (Mathf.Abs(current - flicker) <= rate)//if current and the random flicker are less than rate, change the bulb to be on/off
        {
            if (power == true)
            {
                flickerBulb.intensity = 0;
                power = false;
                
                return;
            }
            if (power == false)
            {
                flickerBulb.intensity = 1;
                power = true;
                
                return;
            }
        }
    }
}
