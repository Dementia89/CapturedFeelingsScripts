using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created by: Dan Cooper
 * Purpose: triggers a sound to play when the player passes by the audio source.
 */
public class SoundTrigger : MonoBehaviour
{
    AudioSource sound;

    // Use this for initialization
    void Start()
    {
        sound = this.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
        }
    }
}
