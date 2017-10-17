using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Anthony
//Modifeid by: Dan

public class LockedDoor : MonoBehaviour
{

    private PlayerControls player;

    private Collision playerColTest;

    private Emotion currentEmotion;

    //public GameObject UnlockedPrefab;

    // Use this for initialization
    void Start()
    {
        //finds player
        player = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        // gets current emotion
        currentEmotion = player.feeling;
        //gets the collsion that occured
        playerColTest = this.GetComponent<CollisionManager>().colInfo;

        // if the lock collided with the player 
        if (playerColTest.gameObject.tag == "Player")
        {
            UnlockDoor();
        }
    }


    // checks to see if we have an emotion or we have a key then destory the lock
    private void UnlockDoor()
    {
        if (currentEmotion != Emotion.Neutral && this.gameObject.tag == "Sign")
        {
            if (currentEmotion == Emotion.Happy)
            {
                Debug.Log("Player is Happy, Door Unlocked!");
                Destroy(this.gameObject);
            }
            if (currentEmotion == Emotion.Sad)
            {
                Debug.Log("Player is Sad, Door Unlocked!");
                Destroy(this.gameObject);
            }
            if (currentEmotion == Emotion.Scared)
            {
                Debug.Log("Player is Scared, Door Unlocked!");
                Destroy(this.gameObject);
            }
            if (currentEmotion == Emotion.Angry)
            {
                Debug.Log("Player is Angry, Door Unlocked!");
                Destroy(this.gameObject);
            }
        }
        else if (this.gameObject.tag != "Sign")
        {
            
            if (this.gameObject.name == "Lock")
            {
                Debug.Log("Player has Key, Door Unlocked!");
                Destroy(this.gameObject);
            }
        }
    }

    private void DestroyLock()
    {
        Destroy(this.gameObject);
        //if (UnlockedPrefab != null)
        //{
        //    Instantiate(UnlockedPrefab, this.transform.position, this.transform.rotation);
        //}
    }
}
