using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    Vector3 throwDirection = Vector3.zero;
    public float throwForce = 10;
    public float tossForce = 1;

    BoxCollider col;

    private PlayerControls playerControlScript;

    private Rigidbody rigBod;

    // Use this for initialization
    void Start()
    {
        playerControlScript = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
        rigBod = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        //playerControlScript.gameObject.GetComponent<Animator>().ResetTrigger("Throw");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1) && !playerControlScript.carryingObject)
        {
            col.enabled = false;
            playerControlScript.carryingObject = true;
            playerControlScript.carriedObject = gameObject.transform;
        }
    }

    public void ThrowObject(Vector3 start, Vector3 end)
    {
        gameObject.transform.position = start;

        throwDirection = new Vector3(end.x - start.x, end.y - start.y, end.z - start.z);
        throwDirection = throwDirection.normalized;

        if (playerControlScript.feeling == Emotion.Angry && playerControlScript.carriedObject.tag != "Suitcase")
        {
            playerControlScript.gameObject.GetComponent<Animator>().SetTrigger("Throw");
            rigBod.velocity = throwDirection * throwForce;
        }
        else
        {
            rigBod.velocity = throwDirection * tossForce;
        }

        col.enabled = true;
    }
}
