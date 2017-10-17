using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Created by: Anthony, Ben, Dan, Gerrit, Jon
// Modified by All

public class PlayerControls : MonoBehaviour
{
    private Transform cam;
    private Vector3 camForward;
    private Transform checkPoint;
    private Rigidbody playerRigBod;
    private Animator anim;
    private CapsuleCollider capCol;

    DateTime invunerability = new DateTime();

    public Transform character;
    public Transform respawnPoint;
    public Transform carryingTarget;
    public Transform carriedObject;

    public Transform throwSource;

    public Collision colInfo;

    public Text healthGT;
    public Canvas deathCanvas;

    public bool carryingObject = false;

    private float h = 0;
    private float v = 0;

    [SerializeField]
    public int health = 5;
    private bool jump = false;
    private bool crouch = false;
    private bool crawling = false;
    private bool invulnerable = false;

    private float gravity = 0.1f;
    private float jumpPower = 4;
    private float walkSpeed = 2;
    private float runSpeed = 5;
    private float distToGround;

    public bool neutral = true;
    public bool sad = false;
    public bool angry = false;
    public bool scared = false;
    public bool happy = false;

    public Emotion feeling;

    // Use this for initialization
    void Start()
    {
        invunerability = DateTime.Now;

        cam = Camera.main.transform;
        playerRigBod = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        capCol = GetComponent<CapsuleCollider>();

        GameObject healthGO = GameObject.Find("HealthText");
        healthGT = healthGO.GetComponent<Text>();
        healthGT.text = "\n  Health: " + health;
    }

    private void Update()
    {

        // Crawl Key Check
        if (sad && Input.GetKeyDown(KeyCode.LeftControl) && !crawling)
        {
            crawling = !crawling;

            if (!anim.GetBool("Crawl"))
            {
                anim.SetBool("Crawl", true);
                capCol.height = 0.74f;
                capCol.center = new Vector3(0, 0.35f, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && crawling)
        {
            anim.SetBool("Crawl", false);
            capCol.height = 1.89f;
            capCol.center = new Vector3(0, 0.92f, 0);
            crawling = !crawling;
        }

        // Carried Object Position Update
        if (carryingObject)
        {
            carriedObject.position = carryingTarget.position;
        }

        if (Input.GetMouseButtonDown(1) && carryingObject)
        {
            //carriedObject.GetComponent<BoxCollider>().enabled = true;
            ThrowObject();
            carryingObject = false;
            carriedObject = null;
        }

        // Jump key check
        if (happy && Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            anim.SetTrigger("Jump");
            jump = true;
            StartCoroutine(Jump());
        }

        if (health <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            deathCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1).normalized);

        if (scared && Input.GetKey(KeyCode.LeftShift))
        {
            h = Input.GetAxis("Horizontal") * runSpeed;
            v = Input.GetAxis("Vertical") * runSpeed;
        }
        else
        {
            h = Input.GetAxis("Horizontal") * walkSpeed;
            v = Input.GetAxis("Vertical") * walkSpeed;
        }

        Vector3 moveDirection = new Vector3(h, playerRigBod.velocity.y, v);

        // Rotation and animation idle/walk/run control
        if (h > 0 || v > 0 || h < 0 || v < 0)
        {
            RotateCharacter(h, v);
            if (scared && Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("Speed", 2);
            }
            else
            {
                anim.SetFloat("Speed", 1);
            }
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        playerRigBod.velocity = moveDirection;
    }


    // Series of methods to change emotion bools
    // for controls. Also animator

    #region Emotion Methods
    public void MakeNeutral()
    {
        feeling = Emotion.Neutral;
        neutral = true;
        sad = false;
        anim.SetBool("Sad", false);
        angry = false;
        anim.SetBool("Angry", false);
        scared = false;
        anim.SetBool("Scared", false);
        happy = false;
        anim.SetBool("Happy", false);
    }

    public void MakeSad()
    {
        feeling = Emotion.Sad;
        neutral = false;
        sad = true;
        anim.SetBool("Sad", true);
        angry = false;
        anim.SetBool("Angry", false);
        scared = false;
        anim.SetBool("Scared", false);
        happy = false;
        anim.SetBool("Happy", false);
    }

    public void MakeAngry()
    {
        feeling = Emotion.Angry;
        neutral = false;
        sad = false;
        anim.SetBool("Sad", false);
        angry = true;
        anim.SetBool("Angry", true);
        scared = false;
        anim.SetBool("Scared", false);
        happy = false;
        anim.SetBool("Happy", false);
    }

    public void MakeScared()
    {
        feeling = Emotion.Scared;
        neutral = false;
        anim.SetBool("Sad", false);
        angry = false;
        anim.SetBool("Angry", false);
        scared = true;
        anim.SetBool("Scared", true);
        happy = false;
        anim.SetBool("Happy", false);
    }

    public void MakeHappy()
    {
        feeling = Emotion.Happy;
        neutral = false;
        anim.SetBool("Sad", false);
        angry = false;
        anim.SetBool("Angry", false);
        scared = false;
        anim.SetBool("Scared", false);
        happy = true;
        anim.SetBool("Happy", true);
    }
    #endregion

    // Character rotation, super messy
    private void RotateCharacter(float h, float v)
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // W & D
        if (h > 0 && v > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0), 0.2f);
        }

        // W & A
        else if (h < 0 && v > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -45, 0), 0.2f);
        }

        // A & S
        else if (h < 0 && v < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -135, 0), 0.2f);
        }

        // S & D
        else if (h > 0 && v < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 135, 0), 0.2f);
        }

        // W
        else if (v > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.2f);
        }

        // A
        else if (h < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 0.2f);
        }

        // S
        else if (v < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), 0.2f);
        }

        // D
        else if (h > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.2f);
        }
    }

    private void ThrowObject()
    {
        RaycastHit rayCastHit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayCastHit, 100);
        carriedObject.GetComponent<Throw>().ThrowObject(throwSource.position, rayCastHit.point);
    }

    // Method placed in NeutralGate class - takes in the neutral gates transform
    // setting the characters privately stored Checkpoint as that location.
    // Updates as a gate is triggered, only remembering the last gate.
    public void CreateCheckpoint(Transform cp)
    {
        checkPoint = cp;
    }

    // Respawn placed in Update of character controls, called once health <=5
    // or the 'R' key is pressed.
    public void Respawn()
    {
        if (checkPoint != null)
        {
            character.transform.position = checkPoint.transform.position;
            Debug.Log("Player Respawned To Checkpoint.");

        }
        else
        {
            character.transform.position = respawnPoint.transform.position;
            Debug.Log("Player Respawned To Start.");
        }
        health = 5;
        healthGT.text = "\n  Health: " + health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Scared Door")
        {
            Debug.Log("Collided With: " + collision.gameObject.name);
            colInfo = collision;
        }

        //If the player collides with an "enemy" 1 health will be lost
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided With: " + collision.gameObject.name);
            colInfo = collision;

            if (invunerability.AddSeconds(2) <= DateTime.Now && !invulnerable)
            {
                TakeDamage();
            }
            else if (invunerability.AddSeconds(3) <= DateTime.Now && invulnerable)
            {
                invulnerable = !invulnerable;
            }

            //A force can be added here to simulate damage knockback

            //Add sound effect for damage effect

        }
    }
    // Wait .5 seconds to jump, match up animation with jump
    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(.5f);
        //playerRigBod.velocity = Vector3.zero;
        playerRigBod.AddForce(0, jumpPower, 0, ForceMode.Impulse);
        jump = false;
    }

    public void TakeDamage()
    {
        health = health - 1;
        healthGT.text = "\n  Health: " + health;
        invunerability = DateTime.Now;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        StartCoroutine(Invulnerable());
        invulnerable = !invulnerable;
    }
    IEnumerator Invulnerable()
    {
        this.GetComponentInChildren<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.3f);
        this.GetComponentInChildren<Renderer>().material.color = Color.grey;
        yield return new WaitForSeconds(.3f);
        this.GetComponentInChildren<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.3f);
        this.GetComponentInChildren<Renderer>().material.color = Color.grey;
        yield return new WaitForSeconds(.3f);
        this.GetComponentInChildren<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.3f);
        this.GetComponentInChildren<Renderer>().material.color = Color.grey;
    }
}

