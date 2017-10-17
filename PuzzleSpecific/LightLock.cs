using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Created by: Dan Cooper
 * Modified by: Anthony
 * Purpose: This script controls the cage light and pressure plate puzzle
 */

public class LightLock : MonoBehaviour
{
    public GameObject[] CageLights;
    private GameObject LockedDoor;


    // Use this for initialization
    void Start()
    {
        CageLights = GameObject.FindGameObjectsWithTag("CageLight");
    }

    // Update is called once per frame
    void Update()
    {
        Count();
    }

    //this will count the number of active lights
    public void Count()
    {
        int activeLights = 0;//this resets each check

        foreach (GameObject l in CageLights)
        {
            
            if (l.GetComponent<CageLight>().lightOn == true)
            {
                activeLights++;
            }
        }

        if (activeLights >= CageLights.Length)
        {
            UnlockDoor();
        }
    }

    void UnlockDoor()
    {
        LockedDoor = GameObject.FindGameObjectWithTag("LightPuzzleDoor");
        LockedDoor.GetComponent<HingeJoint>().useLimits = false;//turns off limits to allow door to open.
        WaypointRoll.isActivated = true;
    }
}
