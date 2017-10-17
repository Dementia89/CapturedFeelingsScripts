using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created by: Dan Cooper
 * Purpose: A customized pressure plate script. The on trigger method activates a function in another script
 */

public class PressurePlateCustom : MonoBehaviour
{
    public float reqWeight;
    private float otherWeight;
    Animator anim;
    public bool triggered = false;
    public AudioSource click;
    public GameObject puzzle;

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
        puzzle.GetComponent<LightLock>().Count();

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
