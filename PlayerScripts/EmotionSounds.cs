using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created by Dan Cooper (Code from Ben Holton)
 * Purpose: Plays sounds for when the player changes emotions. This is attached to the player via an empty game object.
 * 
 */

public class EmotionSounds : MonoBehaviour
{
    public AudioSource soundEffects;
    public AudioClip neutralEffect;
    public AudioClip sadEffect;
    public AudioClip happyEffect;
    public AudioClip angryEffect;
    public AudioClip scaredEffect;

    public PlayerControls player;
    private Emotion currentEmotion = Emotion.Neutral;

    // Use this for initialization
    void Start()
    {
        soundEffects = this.GetComponent<AudioSource>();
        player = GetComponentInParent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.feeling != currentEmotion)
        {
            switch (player.feeling)
            {
                case Emotion.Neutral:
                    soundEffects.clip = neutralEffect;
                    soundEffects.Play();
                    
                    break;
                case Emotion.Angry:
                    soundEffects.clip = angryEffect;
                    soundEffects.Play();
                    
                    break;
                case Emotion.Happy:
                    soundEffects.clip = happyEffect;
                    soundEffects.Play();
                   
                    break;
                case Emotion.Sad:
                    soundEffects.clip = sadEffect;
                    soundEffects.Play();
                    
                    break;
                case Emotion.Scared:
                    soundEffects.clip = scaredEffect;
                    soundEffects.Play();
                    
                    break;
            }
            currentEmotion = player.feeling;
        }
    }
}
