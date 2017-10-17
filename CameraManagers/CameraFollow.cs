using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Anthony
//Modifeid by: Ben
public class CameraFollow : MonoBehaviour
{
    #region Camera Properties
    private Vector3 offset;
    #endregion

    public GameObject player;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = new Vector3(0, 1.5f, -4);

    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        #region Move Code 2.0
        gameObject.transform.position = player.transform.position + offset;
        #endregion
    }
}
