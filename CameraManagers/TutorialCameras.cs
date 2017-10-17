using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCameras : MonoBehaviour {

    private GameObject camera;
    private GameObject player;

    public bool roomActive = false;

    private void Start()
    {
        camera = Camera.main.gameObject;
        player = GameObject.Find("PlayerCharacter");
    }

    private void Update()
    {
        if (roomActive)
        {
            camera.transform.LookAt(player.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            camera.GetComponent<CameraFollow>().enabled = false;
            camera.transform.position = gameObject.transform.position;
            roomActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            roomActive = false;
            camera.GetComponent<CameraFollow>().enabled = true;
            camera.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            camera.GetComponent<CameraFollow>().enabled = false;
        }
    }
}
