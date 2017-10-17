using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Gerrit

[RequireComponent(typeof(AudioSource))]
public class FootStepR : MonoBehaviour
{
    //Audio Holder
    public AudioClip[] neutralClips;
    public AudioClip[] happyClips;
    public AudioClip[] sadClips;
    public AudioClip[] angryClips;
    public AudioClip[] scaredClips;
    private AudioSource a;

    //Timer Reset values to determine when a new step noise can be played.
    private const float neutraltimerReset = 0.4f;
    private const float happytimerReset = 0.4f;
    private const float scaredtimerReset = 0.1f;
    private const float angrytimerReset = 0.4f;
    private const float sadtimerReset = 0.35f;

    //Step tracker
    public int stepNum = 0;
    private bool once = false;


    private SphereCollider sphereCol;
    private PlayerControls player;

    //On awake, get these!
    private void Awake()
    {
        a = GetComponent<AudioSource>();
        player = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
        sphereCol = GetComponent<SphereCollider>();

    }

    //Once the foot has reached the ground and triggered the collider...
    private void OnTriggerEnter(Collider col)
    {
        //Check what feeling is active and play according footsteps.
        if (player.neutral == true)
        {
            a.volume = .8f;
            sphereCol.center = new Vector3(0, 0, 0.1f);
            sphereCol.radius = .08f;
            PlayNeutralStep(col);
        }

        if (player.happy == true)
        {
            a.volume = .7f;
            sphereCol.center = new Vector3(0, -0.1f, 0.1f);
            sphereCol.radius = .07f;
            PlayHappyStep(col);
        }

        if (player.sad == true)
        {
            a.volume = 1f;
            sphereCol.center = new Vector3(0, -0.1f, 0.1f);
            sphereCol.radius = .08f;
            PlaySadStep(col);
        }

        if (player.angry == true)
        {
            a.volume = 1f;
            sphereCol.center = new Vector3(0, 0, 0.1f);
            sphereCol.radius = .08f;
            PlayAngryStep(col);
        }

        if (player.scared == true)
        {
            PlayScaredStep(col);
        }

    }

    //Reset counter w/sound list of 4
    private void Reset()
    {
        once = false;
        if (stepNum >= 4)
        {
            stepNum = 0;
        }
    }

    //Play Neutral Step Sounds
    private void PlayNeutralStep(Collider col)
    {
        string currentTag = col.tag;
        if (currentTag == "Floor" && !once)
        {
            //randomize pitch
            a.pitch = (Random.Range(0.7f, .8f));

            //play 1 sounds clip
            a.PlayOneShot(neutralClips[stepNum]);

            //has stepped
            once = true;

            //play the next sound
            stepNum++;

            //reset the next step after a certain amount of time
            Invoke("Reset", neutraltimerReset);
        }
    }

    //Play Happy Step Sounds
    private void PlayHappyStep(Collider col)
    {
        string currentTag = col.tag;
        if (currentTag == "Floor" && !once)
        {
            //randomize pitch
            a.pitch = (Random.Range(0.6f, 0.7f));

            //play 1 sounds clip
            a.PlayOneShot(happyClips[stepNum]);

            //has stepped
            once = true;

            //play the next sound
            stepNum++;

            //reset the next step after a certain amount of time
            Invoke("Reset", happytimerReset);
        }
    }

    //Play Scared Step Sounds
    private void PlayScaredStep(Collider col)
    {
        string currentTag = col.tag;
        if (currentTag == "Floor" && !once)
        {
            //randomize pitch
            a.pitch = (Random.Range(0.3f, 0.7f));

            //play 1 sounds clip
            a.PlayOneShot(scaredClips[stepNum]);

            //has stepped
            once = true;

            //play the next sound
            stepNum++;

            //reset the next step after a certain amount of time
            Invoke("Reset", scaredtimerReset);
        }
    }

    //Play Angry Step Sounds
    private void PlayAngryStep(Collider col)
    {
        string currentTag = col.tag;
        if (currentTag == "Floor" && !once)
        {
            //randomize pitch
            a.pitch = (Random.Range(0.3f, 0.7f));

            //play 1 sounds clip
            a.PlayOneShot(angryClips[stepNum]);

            //has stepped
            once = true;

            //play the next sound
            stepNum++;

            //Reset the next step after a certain amount of time
            Invoke("Reset", angrytimerReset);
        }
    }

    //Play Sad Step Sounds
    private void PlaySadStep(Collider col)
    {
        string currentTag = col.tag;
        if (currentTag == "Floor" && !once)
        {
            //randomize pitch
            a.pitch = (Random.Range(0.3f, 0.5f));

            //play 1 sounds clip
            a.PlayOneShot(sadClips[stepNum]);

            //has stepped
            once = true;

            //play the next sound
            stepNum++;

            //reset the next step after a certain amount of time
            Invoke("Reset", sadtimerReset);
        }
    }

}