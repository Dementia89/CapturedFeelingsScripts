using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * For use with ceiling traps. Will delete the ceiling tile to make objects fall down from above 
 * Requires: Any ceiling tile and a spawnable object 
 */

public class CeilingTrap : MonoBehaviour
{
    public GameObject CeilingTile;
    public GameObject[] spawns = new GameObject[1];
    AudioSource sound;

    public Emotion RequiredEmotion = Emotion.Scared; //TODO: PLEASE REPLACE WITH THE PROPER EMOTION CODE. This is for testing only
    public Emotion playerEmotion;
    bool ImEmotional;

    private PlayerControls playerController;

    public bool triggered = false;

    // Use this for initialization
    void Start()
    {
        playerController = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
        foreach (GameObject o in spawns)
        {
            o.SetActive(false);//hides objects until they are needed
        }
        sound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerEmotion = Colors.emotion;
        if (RequiredEmotion == playerController.feeling)
            ImEmotional = true;
        else
            ImEmotional = false;

    }

    private void OnTriggerEnter(Collider co)
    {
        if(co.tag == "Player")
        {
            foreach (GameObject o in spawns)
            {
                o.SetActive(true);//spawns objects, but they wont drop until the proper emotion is active
            }
        }
    }

    private void OnTriggerExit(Collider co)
    {
        if (co.tag == "Player")
        {
            if (triggered == false)
            {
                foreach (GameObject o in spawns)
                {
                    o.SetActive(false);//despawns objects when the player leaves the room
                }
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerStay(Collider co)
    {
        //if the player stays within the trap radius and the emotion is active, then the trap activates

        if(co.tag == "Player" && ImEmotional == true)
        {
            CeilingTile.SetActive(false);//removes ceiling tile
            //sound.Play();                                   //Doesnt work here. Sound plays continuously until the player leaves the room
            triggered = true;
        }
    }
}
