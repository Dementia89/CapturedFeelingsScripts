using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource neutralMusic;
    public AudioSource sadMusic;
    public AudioSource angryMusic;
    public AudioSource scaredMusic;
    public AudioSource happyMusic;
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
        player = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
        AudioSource[] tracks = GetComponents<AudioSource>();
        foreach(AudioSource audio in tracks)
        {
            if(audio.clip != null)
            {
                switch (audio.clip.name)
                {
                    case "Neutral":
                        neutralMusic = audio;
                        break;
                    case "angry":
                        angryMusic = audio;
                        break;
                    case "sad":
                        sadMusic = audio;
                        break;
                    case "scared":
                        scaredMusic = audio;
                        break;
                    case "happy":
                        happyMusic = audio;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.feeling != currentEmotion)
        {
            switch (player.feeling)
            {
                case Emotion.Neutral:
                    soundEffects.clip = neutralEffect;
                    soundEffects.Play();
                    neutralMusic.volume = 1;
                    angryMusic.volume = 0;
                    sadMusic.volume = 0;
                    happyMusic.volume = 0;
                    scaredMusic.volume = 0;
                    break;
                case Emotion.Angry:
                    soundEffects.clip = angryEffect;
                    soundEffects.Play();
                    neutralMusic.volume = 0;
                    angryMusic.volume = 1;
                    sadMusic.volume = 0;
                    happyMusic.volume = 0;
                    scaredMusic.volume = 0;
                    break;
                case Emotion.Happy:
                    soundEffects.clip = happyEffect;
                    soundEffects.Play();
                    neutralMusic.volume = 0;
                    angryMusic.volume = 0;
                    sadMusic.volume = 0;
                    happyMusic.volume = 1;
                    scaredMusic.volume = 0;
                    break;
                case Emotion.Sad:
                    soundEffects.clip = sadEffect;
                    soundEffects.Play();
                    neutralMusic.volume = 0;
                    angryMusic.volume = 0;
                    sadMusic.volume = 1;
                    happyMusic.volume = 0;
                    scaredMusic.volume = 0;
                    break;
                case Emotion.Scared:
                    soundEffects.clip = scaredEffect;
                    soundEffects.Play();
                    neutralMusic.volume = 0;
                    angryMusic.volume = 0;
                    sadMusic.volume = 0;
                    happyMusic.volume = 0;
                    scaredMusic.volume = 1;
                    break;
            }
            currentEmotion = player.feeling;
        }
    }
}
