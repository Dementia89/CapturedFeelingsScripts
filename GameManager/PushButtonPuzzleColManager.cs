using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Anthony
//Modifeid by:
public class PushButtonPuzzleColManager : MonoBehaviour
{
    public Collision colInfo;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PushButton")
        {
            Debug.Log("Collided With: " + collision.gameObject.name);
            colInfo = collision;
            return;
        }
    }
}
