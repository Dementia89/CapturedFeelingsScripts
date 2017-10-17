using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningJars : MonoBehaviour
{
    public Emotion emotionInJar;

    public GameObject HappyJar;
    public GameObject AngryJar;
    public GameObject SadJar;
    public GameObject ScaredJar;
    public GameObject BrokenJar;

    public GameObject currentJar;

    public bool playerInRoom = false;

    // Use this for initialization
    void Start()
    {
        currentJar = Instantiate(SelectJar(emotionInJar), gameObject.transform.position, gameObject.transform.rotation);
    }

    private void Update()
    {
        //if(currentJar == null && !playerInRoom)
        //{
        //    StartCoroutine(WaitForSpawn());
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRoom = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && currentJar == null)
        {
            playerInRoom = false;
            StartCoroutine(WaitForSpawn());
        }
    }

    private GameObject SelectJar(Emotion emotion)
    {
        switch (emotion)
        {
            case Emotion.Angry:
                return AngryJar;
            case Emotion.Happy:
                return HappyJar;
            case Emotion.Sad:
                return SadJar;
            case Emotion.Scared:
                return ScaredJar;
            default:
                return BrokenJar;
        }
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(10);
        currentJar = Instantiate(SelectJar(emotionInJar), gameObject.transform.position, gameObject.transform.rotation);
    }
}
