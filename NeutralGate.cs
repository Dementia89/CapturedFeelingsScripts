using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modified by Gerrit

public class NeutralGate : MonoBehaviour
{
    public Transform gate;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider co)
    {
        if (co.tag == "Player")
        {
            PlayerControls pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
            pc.MakeNeutral();
            pc.CreateCheckpoint(gate);
            Camera.main.GetComponent<Colors>().emotion = Emotion.Neutral;
        }
    }
}
