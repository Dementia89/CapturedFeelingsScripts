using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Anthony
//Modifeid by: Anthony

public class ScaredSpawner : MonoBehaviour
{
    private PlayerControls player;

    System.DateTime oldTime;
    System.DateTime newTime;

    private Collision objectColTest;
    private Collision playerColTest;

    private GameObject[] spawner;

    public bool spawned;
    // Use this for initialization
    void Start()
    {
        spawned = false;

        player = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
        spawner = GameObject.FindGameObjectsWithTag("ScaredObjectSpawn");

        spawnedObjects();

        oldTime = new System.DateTime();
    }

    // Update is called once per frame
    void Update()
    {
        // check to see if player collided with the Scared Door
        playerColTest = player.GetComponent<PlayerControls>().colInfo;

        foreach (GameObject spawned in spawnedObjects())
        {
            if (spawned != null)
            {
                // check to see if we collided with the floor
                objectColTest = spawned.GetComponent<CollisionManager>().colInfo;
            }
        }

        if (player.scared && playerColTest != null)
        {
            newTime = System.DateTime.Now;

            if (newTime >= oldTime.AddSeconds(.5f))
            {
                ScaredObject();
            }
        }
    }

    // scared object spawn method
    private void ScaredObject()
    {
        // choose object to spawn
        int choice = Random.Range(1, 5);

        // check to see if spawned
        if (choice == 1)
        {
            // if the object did not collide with floor
            if (objectColTest == null)
            {
                GameObject value = spawnedObjects().GetValue(Random.Range(0, spawnedObjects().Length + 1)) as GameObject;
                if (value != null)
                {
                    Instantiate(value, spawner[Random.Range(0, 3)].transform.position, spawner[Random.Range(0, 3)].transform.rotation);

                    oldTime = newTime;
                    spawned = true;
                }
            }
        }
        if (choice == 2)
        {

            if (objectColTest == null)
            {
                GameObject value = spawnedObjects().GetValue(Random.Range(0, spawnedObjects().Length + 1)) as GameObject;
                if (value != null)
                {
                    Instantiate(value, spawner[Random.Range(0, 3)].transform.position, spawner[Random.Range(0, 3)].transform.rotation);

                    oldTime = newTime;
                    spawned = true;
                }
            }
        }
        if (choice == 3)
        {

            if (objectColTest == null)
            {
                GameObject value = spawnedObjects().GetValue(Random.Range(0, spawnedObjects().Length + 1)) as GameObject;
                if (value != null)
                {
                    Instantiate(value, spawner[Random.Range(0, 3)].transform.position, spawner[Random.Range(0, 3)].transform.rotation);

                    oldTime = newTime;
                    spawned = true;
                }
            }
        }
        if (choice == 4)
        {
            if (objectColTest == null)
            {
                GameObject value = spawnedObjects().GetValue(Random.Range(0, spawnedObjects().Length + 1)) as GameObject;
                if (value != null)
                {
                    Instantiate(value, spawner[Random.Range(0, 3)].transform.position, spawner[Random.Range(0, 3)].transform.rotation);

                    oldTime = newTime;
                    spawned = true;
                }
            }
        }

    }

    private GameObject[] spawnedObjects()
    {
        CollisionManager[] collisionObjects = FindObjectsOfType<CollisionManager>();
        GameObject[] spawnedObjects = new GameObject[collisionObjects.Length];

        for (int i = 0; i < spawnedObjects.Length; ++i)
        {
            if (collisionObjects[i].GetComponent<LockedDoor>() == false && collisionObjects[i] != null)
            {
                spawnedObjects[i] = collisionObjects[i].gameObject;
            }
        }
        return spawnedObjects;
    }
}
