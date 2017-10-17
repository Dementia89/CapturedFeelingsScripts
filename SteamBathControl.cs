using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created by: Dan
//Modifeid by: Anthony

public class SteamBathControl : MonoBehaviour
{
    Animator anim;
    bool open = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (!open)
        {
            anim.SetBool("Open", true);
            open = true;
        }
        else
        {
            anim.SetBool("Open", false);
            open = false;
        }
    }
}
