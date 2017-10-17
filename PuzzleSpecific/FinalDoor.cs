using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Light doorLight; //light above the door, will light up when final puzzle is done
    public GameObject LockedDoor;
    public GameObject[] CageLights;
    public GameObject Plate;
    

    // Use this for initialization
    void Start()
    {
        doorLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Plate.GetComponent<PressurePlates>().triggered == true)
        {
            doorLight.intensity = 2;
        }

        if (Plate.GetComponent<PressurePlates>().triggered == false)
        {
            doorLight.intensity = 0;
        }
    }

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
