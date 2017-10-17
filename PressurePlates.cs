using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created by: Dan Cooper
 * Modified by: 
 * Purpose: use on pressure plates. Set the required weight in the inspector and then it will compare the object's 
 * Rigidbody mass to the required weight. The triggered bool will activate when the required weight is met.
 */

public class PressurePlates : MonoBehaviour
{
    public float reqWeight;
    private float otherWeight;
    Animator anim;
    public bool triggered = false;
    public AudioSource click;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        click = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        click.pitch = 1;
        click.Play();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Foot")
        {
            otherWeight = GetComponentInParent<Rigidbody>().mass;
        }
        else
        {
            otherWeight = other.GetComponent<Rigidbody>().mass;
        }
        if (otherWeight >= reqWeight)
        {
            Press();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Depress();
    }

    private void Press()
    {
        triggered = true;
        anim.SetBool("Pressed", true);
    }

    private void Depress()
    {
        triggered = false;
        anim.SetBool("Pressed", false);
        click.pitch = .5f;
        click.Play();
    }
}
