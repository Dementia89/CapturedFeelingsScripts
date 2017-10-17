using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padlock : MonoBehaviour
{
    private GameObject Lock;
    private string reqKey;
    

    private string tags;

    // Use this for initialization
    void Start()
    {
        Lock = this.gameObject;

        tags = this.gameObject.tag;

        switch (tags)
        {
            case "GreenLock":
                reqKey = "GreenKey";
                break;
            case "RedLock":
                reqKey = "RedKey";
                break;
            case "BlueLock":
                reqKey = "BlueKey";
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == reqKey)
        {
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        Destroy(this.gameObject);
    }
}
