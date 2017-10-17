using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Dan
//Modifeid by: Anthony

public class WeatherControl : MonoBehaviour
{
    public Light sun;//main distant light in scene

    public PlayerControls player;

    //Sad emotion specific
    public GameObject[] Rain;
    public AudioSource RainSound;

    //scared emotion specific
    public Light lightning;
    

    //angry emotion specific
    //public GameObject fireballPlacer;//empty game object
    //public GameObject fire;//fire particle

    [Space]
    [Space]
    [Space]
    //sunlight colors
    public Color HappyC, SadC, AngryC, ScaredC, NeutralC;


    //emotion control
    private Emotion oldEmotion, newEmotion;


    // Use this for initialization
    void Start()
    {
        newEmotion = Emotion.Neutral;
        oldEmotion = newEmotion;
        Rain = GameObject.FindGameObjectsWithTag("Rain System");

        //make sure other effects are not on when starting the game
        RemSad();
        RemScared();

        player = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        newEmotion = player.feeling;

        if (newEmotion == oldEmotion)//this is to prevent Unity from setting the same color to every object every update. 
            return;                  //An emotion change must occur for this to be called
        if (newEmotion != oldEmotion)
        {
            switch (oldEmotion)//remove old weather
            {
                case Emotion.Angry:
                    RemAngry();
                    break;
                case Emotion.Happy:
                    RemHappy();
                    break;
                case Emotion.Sad:
                    RemSad();
                    break;
                case Emotion.Scared:
                    RemScared();
                    break;
                case Emotion.Neutral:
                    RemNeutral();
                    break;
            }

            switch (newEmotion)//apply new weather
            {
                case Emotion.Angry:
                    SetAngry();
                    break;
                case Emotion.Happy:
                    SetHappy();
                    break;
                case Emotion.Sad:
                    SetSad();
                    break;
                case Emotion.Scared:
                    SetScared();
                    break;
                case Emotion.Neutral:
                    SetNeutral();
                    break;
            }

            oldEmotion = newEmotion;
        }

    }

    private void SetSad()
    {
        foreach (GameObject r in Rain)
        {
            r.SetActive(true);
        }
        RainSound.Play();
        sun.color = SadC;
        sun.intensity = .7f;
    }

    private void RemSad()
    {
        foreach (GameObject r in Rain)
        {
            r.SetActive(false);
        }
        RainSound.Stop();
    }

    private void SetScared()
    {
        Lightning.LightningActive = true;
        sun.color = ScaredC;
        sun.intensity = .5f;
    }

    private void RemScared()
    {
        Lightning.LightningActive = false;
    }

    private void SetHappy()
    {
        sun.color = HappyC;
        sun.intensity = 1.3f;
    }

    private void RemHappy()
    {

    }

    private void SetNeutral()
    {
        sun.color = NeutralC;
        sun.intensity = 1;
    }

    private void RemNeutral()
    {

    }

    private void SetAngry()
    {
        sun.color = AngryC;
        sun.intensity = 1;
    }

    private void RemAngry()
    {

    }

}
