using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    public Material Primary;
    public Material Secondary;
    public Material Accent;

    //public Material PrimaryTransparent;
    //public Material SecondaryTransparent;
    //public Material AccentTransparent;

    //simple labels for the colors. Helps with readability
    private int P = 0;//primary
    private int S = 1;//secondary
    private int A = 2;//accent

    public Color[] Neutral = new Color[3];
    public Color[] Angry = new Color[3];
    public Color[] Sad = new Color[3];
    public Color[] Happy = new Color[3];
    public Color[] Scared = new Color[3];

    public PlayerControls player;

    private Emotion oldEmotion, newEmotion;

    public Emotion emotion;

    // Use this for initialization
    void Start()
    {
        newEmotion = Emotion.Neutral;
        oldEmotion = newEmotion;

        player = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();

        // So colors are always neutral on game start.
        Primary.color = Neutral[P];
        Secondary.color = Neutral[S];
        Accent.color = Neutral[A];
    }

    // Update is called once per frame
    void Update()
    {
        newEmotion = player.feeling;
        emotion = newEmotion;

        if (newEmotion == oldEmotion)//this is to prevent Unity from setting the same color to every object every update. 
            return;                  //An emotion change must occur for this to be called
        if (newEmotion != oldEmotion)
        {
            switch (newEmotion)
            {
                case Emotion.Angry:
                    Primary.color = Angry[P];
                    Secondary.color = Angry[S];
                    Accent.color = Angry[A];
                    break;
                case Emotion.Happy:
                    Primary.color = Happy[P];
                    Secondary.color = Happy[S];
                    Accent.color = Happy[A];
                    break;
                case Emotion.Sad:
                    Primary.color = Sad[P];
                    Secondary.color = Sad[S];
                    Accent.color = Sad[A];
                    break;
                case Emotion.Scared:
                    Primary.color = Scared[P];
                    Secondary.color = Scared[S];
                    Accent.color = Scared[A];
                    break;
                case Emotion.Neutral:
                    Primary.color = Neutral[P];
                    Secondary.color = Neutral[S];
                    Accent.color = Neutral[A];
                    break;
            }

            oldEmotion = newEmotion;
        }
        
    }
}
