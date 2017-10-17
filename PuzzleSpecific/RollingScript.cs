using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created By Jon

public class RollingScript : MonoBehaviour {

    public float x, y, z;
    public string tagName;
    public Transform respawnPoint;
    private bool hasCollided;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == tagName)
        {
            if (!hasCollided)
            {
                GetComponent<Rigidbody>().AddForce(x * GetComponent<Rigidbody>().mass, y * GetComponent<Rigidbody>().mass, z * GetComponent<Rigidbody>().mass);
                GetComponent<Rigidbody>().useGravity = false;
                hasCollided = true;
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            GetComponent<Rigidbody>().AddForce(0, y * GetComponent<Rigidbody>().mass, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            transform.position = respawnPoint.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = true;
            hasCollided = false;
        }
    }


}
