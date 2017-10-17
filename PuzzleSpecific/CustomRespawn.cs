using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created by Dan Cooper
 * Purpose: used to reset the final trap in Level 2. This script replaces the trap back at its original starting point
 * and relocks the door.
 */

public class CustomRespawn : MonoBehaviour
{
    private Vector3 StartingPoint;
    public GameObject door;
    GameObject player;
    


    // Use this for initialization
    void Start()
    {
        StartingPoint = this.transform.position;//get starting point
        player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.GetComponent<PlayerControls>().health < 1)
        //{
        //    Restart();
        //}
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerControls>().health <= 1)
            {
                Restart();
            }
            else
            {
                other.gameObject.GetComponent<PlayerControls>().TakeDamage();
            }
        }
    }
    private void Restart()
    {
        this.transform.position = StartingPoint;//place back at starting point
        this.transform.rotation = Quaternion.Euler(0,0,90);
        WaypointRoll.isActivated = false;//turn trap off
        door.GetComponent<HingeJoint>().useLimits = true; //relock door
        //player.transform.position = GameObject.Find("PressurePlate (4)").transform.position;
    }
}
