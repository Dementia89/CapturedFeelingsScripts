using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Jon
//Modified by: Anthony

public class PositionReset : MonoBehaviour
{
    private Transform player;
    private Transform positionCheck;

    public void Start()
    {
        positionCheck = this.GetComponent<Transform>();
    }
    public void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (player.position.y < positionCheck.position.y)
        {
            player.position = GameObject.Find("RespawnPoint").GetComponent<Transform>().position;
        }
    }
}
