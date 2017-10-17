using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Anthony
//Modifed by: 
public class PushButtonPuzzle : MonoBehaviour
{
    public GameObject[] buttons;
    public Light[] bulbs;

    private Collision objColTest;
    private GameObject[] obj;
    // Use this for initialization
    void Start()
    {
        obj = GameObject.FindGameObjectsWithTag("Shoebox");

        foreach (Light l in bulbs)
        {
            l.intensity = 0;//turn off all lights
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject shoebox in obj)
        {
            if (shoebox.GetComponent<PushButtonPuzzleColManager>() == true)
            {
                //gets the collsion that occured
                objColTest = shoebox.GetComponent<PushButtonPuzzleColManager>().colInfo;
            }

            if (objColTest != null)
            {
                PushButtonActivate();
            }
        }
       
    }

    private void PushButtonActivate()
    {
        // Turns off and On Lights
        if (objColTest.gameObject.name == "PushButton1")
        {
            bulbs[0].intensity = 1;
            bulbs[2].intensity = 1;
        }
        if (objColTest.gameObject.name == "PushButton2")
        {
            bulbs[1].intensity = 0;
        }
        if (objColTest.gameObject.name == "PushButton3")
        {
            bulbs[0].intensity = 0;
            bulbs[1].intensity = 1;
        }
    }
}
