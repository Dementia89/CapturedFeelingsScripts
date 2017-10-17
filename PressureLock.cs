using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created by: Dan Cooper
 * Purpose: Place on doors and then add a pressure plate to control the door's locking mechanism. The door
 * must have a Unity Hinge joint.
 * 
 */

public class PressureLock : MonoBehaviour
{
    public GameObject Plate;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<HingeJoint>().useLimits = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Plate.GetComponent<PressurePlates>().triggered == true)
        {
            Unlock();
        }

        if(Plate.GetComponent<PressurePlates>().triggered == false)
        {
            Lock();
        }
    }

    private void Unlock()
    {
        this.GetComponent<HingeJoint>().useLimits = false;
        //this.GetComponent<HingeJoint>().useSpring = false;
    }

    private void Lock()
    {
        //this.GetComponent<HingeJoint>().spring = 1;
        this.GetComponent<HingeJoint>().useLimits = true;
    }
}
