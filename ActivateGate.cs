using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Created by Dan Cooper
 * Purpose: Activates a neutral gate (or any object) when a pressure plate is activated
 * 
 */
public class ActivateGate : MonoBehaviour
{
    public GameObject Plate;
    GameObject gate;

    // Use this for initialization
    void Start()
    {
        gate = GetComponentInChildren<NeutralGate>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Plate.GetComponent<PressurePlates>().triggered == true)
        {
            Unlock();
        }

        if (Plate.GetComponent<PressurePlates>().triggered == false)
        {
            Lock();
        }
    }
    private void Unlock()
    {
        gate.SetActive(true);
    }

    private void Lock()
    {
        gate.SetActive(false);
    }
}
