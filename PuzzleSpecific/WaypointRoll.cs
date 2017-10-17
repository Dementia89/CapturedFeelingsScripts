using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Jon

public class WaypointRoll : MonoBehaviour
{

    public float speed, xAngle, yAngle, zAngle;

    public Transform[] waypoints;
    public bool loops;
    public bool alwaysActive;
    public static bool isActivated;
    private Transform activeWaypoint;
    private int waypointNumber = 0;




    void Start()
    {
        transform.eulerAngles = new Vector3(xAngle, yAngle, zAngle);
        activeWaypoint = waypoints[waypointNumber];
        if (alwaysActive)
        {
            isActivated = true;
        }
    }

    void Update()
    {
        if (isActivated)
        {
            if (waypointNumber < waypoints.Length)
            {
                transform.position = Vector3.MoveTowards(transform.position, activeWaypoint.position, speed);
            }
            else
            {
                if (loops)
                {
                    waypointNumber = 0;
                    activeWaypoint = waypoints[waypointNumber];
                }
                else
                {
                    speed = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Waypoint")
        {
            transform.eulerAngles = activeWaypoint.eulerAngles;
            waypointNumber += 1;
            activeWaypoint = waypoints[waypointNumber];
        }
    }
}