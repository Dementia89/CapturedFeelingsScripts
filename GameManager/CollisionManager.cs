using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Anthony
//Modifeid by: Anthony, Ben
public class CollisionManager : MonoBehaviour
{
    public Collision colInfo = null;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("Collided With: " + collision.gameObject.name);
            colInfo = collision;
            Destroy(this.gameObject);
            return;
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided With: " + collision.gameObject.name);
            colInfo = collision;
            //collision.gameObject.GetComponent<PlayerControls>().TakeDamage();
            return;
        }
        else if (collision.gameObject.tag == "PushButton")
        {
            Debug.Log("Collided With: " + collision.gameObject.name);
            colInfo = collision;
            return;
        }
        else
        {
            colInfo = null;
        }
    }
}
