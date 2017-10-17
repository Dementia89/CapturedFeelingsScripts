using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakImp : MonoBehaviour
{
    public float breakVelocity = 2f;

    public GameObject brokenJar;

    public Emotion emotion;

    private PlayerControls playerController;

    private void Start()
    {
        playerController = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
    }

    private void OnMouseDown()
    {
        Instantiate(brokenJar, gameObject.transform.position, gameObject.transform.rotation);

        BestowFeeling(emotion);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.magnitude > breakVelocity)
        {
            Instantiate(brokenJar, gameObject.transform.position, gameObject.transform.rotation);

            BestowFeeling(emotion);

            Destroy(gameObject);
        }
    }

    public void BestowFeeling(Emotion emotion)
    {
        switch (emotion)
        {
            case Emotion.Neutral:
                //pc.MakeNeutral();
                break;
            case Emotion.Angry:
                playerController.MakeAngry();
                break;
            case Emotion.Happy:
                playerController.MakeHappy();
                break;
            case Emotion.Sad:
                playerController.MakeSad();
                break;
            case Emotion.Scared:
                playerController.MakeScared();
                break;
        }
    }
}
