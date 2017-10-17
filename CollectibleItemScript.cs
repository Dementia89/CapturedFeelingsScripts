using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Dan
// Modified by Jon
// Modified by Gerrit

public class CollectibleItemScript : MonoBehaviour
{

    public GameObject particles;
    public CollectibleMenu cm;
    private bool played = false;


    void Start()
    {
        //Instantiate(this, this.transform.position, this.transform.rotation, this.transform); This code is not needed anymore
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && (Vector3.Distance(GameObject.Find("PlayerCharacter").transform.position, gameObject.transform.position) < 3))
        {
            particles.SetActive(false);
            cm.isActivated = true;

            if (played == false)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                played = true;
            }
            
        }
    }
}
