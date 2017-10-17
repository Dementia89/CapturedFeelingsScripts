using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    private PlayerControls player;
    private PushButtonPuzzle puzzle;

    private Collision playerColTest;
    // Use this for initialization
    void Start()
    {
        //finds player
        player = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets the collsion that occured
        playerColTest = this.GetComponent<CollisionManager>().colInfo;

        if (playerColTest.gameObject.tag == "Player")
        {
            puzzle = GameObject.Find("PushButtonPuzzle").GetComponent<PushButtonPuzzle>();

            if (puzzle.bulbs[0].intensity == 1 && puzzle.bulbs[1].intensity == 1 && puzzle.bulbs[2].intensity == 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
