using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created by: Dan
//Modifeid by: Anthony

public class TreeControl : MonoBehaviour
{
    public GameObject HappyTree, SadTree, AngryTree, ScaredTree, NeutralTree;
    GameObject oldTree;

    private PlayerControls player;

    private Emotion oldEmotion, newEmotion;

    private Emotion emotion;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
        oldTree = Instantiate(NeutralTree, transform.position, transform.rotation, this.gameObject.transform);

        newEmotion = Emotion.Neutral;
        oldEmotion = newEmotion;
    }

    // Update is called once per frame
    void Update()
    {
        newEmotion = player.feeling;

        if (newEmotion == oldEmotion)//this is to prevent Unity from setting the same color to every object every update. 
            return;                  //An emotion change must occur for this to be called

        if (newEmotion != oldEmotion)
        {
            switch (newEmotion)
            {
                case Emotion.Angry:
                    Destroy(oldTree);
                    oldTree = Instantiate(AngryTree, transform.position, transform.rotation, this.gameObject.transform);
                    break;
                case Emotion.Happy:
                    Destroy(oldTree);
                    oldTree = Instantiate(HappyTree, transform.position, transform.rotation, this.gameObject.transform);
                    break;
                case Emotion.Sad:
                    Destroy(oldTree);
                    oldTree = Instantiate(SadTree, transform.position, transform.rotation);
                    break;
                case Emotion.Scared:
                    Destroy(oldTree);
                    oldTree = Instantiate(ScaredTree, transform.position, transform.rotation);
                    break;
                case Emotion.Neutral:
                    Destroy(oldTree);
                    oldTree = Instantiate(NeutralTree, transform.position, transform.rotation);
                    break;
            }

            oldEmotion = newEmotion;
        }

    }
}
