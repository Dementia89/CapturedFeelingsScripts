using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Created by: Dan Cooper
 * Purpose: This script is attached to a game object with a large collider box and a trigger box. The player
 * cannot pass until they have the required emotion.
 */
public class EmotionLock : MonoBehaviour
{
    private PlayerControls playerController;
    public Emotion ReqEmotion;

    // Use this for initialization
    void Start()
    {
        playerController = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && playerController.feeling == ReqEmotion)
        {
            Destroy(gameObject);
        }
    }

    
}
