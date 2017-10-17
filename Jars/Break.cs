using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject BreakablePrefab;

    public BoxCollider col;
    
    public Emotion emotion;

    public Vector3 beginThrow;
    public Vector3 endThrow;
    public bool thrown = false;
    float flyTime = 0.25f;
    float startTime;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (thrown && emotion == Emotion.Angry)
        {
            Vector3 center = (beginThrow + endThrow) * 0.5f;
            center -= new Vector3(0, 1, 0);
            Vector3 startRelCenter = beginThrow - center;
            Vector3 endRelCenter = endThrow - center;
            float fracComplete = (Time.time - startTime) / flyTime;
            transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete);
            transform.position += center;

            if(gameObject.transform.position == endThrow && gameObject.tag == "Jar")
            {
                thrown = false;
                if(gameObject.tag == "Jar")
                {
                    BreakJar();
                }
            }
        }
        else if (thrown)
        {
            PlayerControls pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
            pc.carryingObject = false;
            pc.carriedObject = null;
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && (Vector3.Distance(GameObject.Find("PlayerCharacter").transform.position, gameObject.transform.position) < 3))
        {
            BreakJar();
        }

        // If right click, have the player carry it.
        if (Input.GetMouseButtonUp(1) && (Vector3.Distance(GameObject.Find("PlayerCharacter").transform.position, gameObject.transform.position) < 2))
        {
            Debug.Log("Right clicked on jar");
            PlayerControls pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();
            if (!pc.carryingObject)
            {
                col.enabled = false;
                pc.carriedObject = gameObject.transform;
                pc.carryingObject = true;
            }
        }
    }

    public void BreakJar()
    {
        BreakablePrefab.transform.localScale = gameObject.transform.localScale;//This line will scale the broken object to be the same size
                                                                               //as the initial object
        Instantiate(BreakablePrefab, transform.position, transform.rotation);

        if(emotion != Emotion.Neutral)
        {
            Camera.main.GetComponent<Colors>().emotion = emotion;
        }

        PlayerControls pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerControls>();

        // Changes player characters emotions for control purposes
        switch (emotion)
        {
            case Emotion.Neutral:
                //pc.MakeNeutral();
                break;
            case Emotion.Angry:
                pc.MakeAngry();
                break;
            case Emotion.Happy:
                pc.MakeHappy();
                break;
            case Emotion.Sad:
                pc.MakeSad();
                break;
            case Emotion.Scared:
                pc.MakeScared();
                break;
        }

        Destroy(gameObject);

        //Send the pieces flying
        //BreakablePrefab.GetComponentInChildren<Rigidbody>().velocity = new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3));
        //BreakablePrefab.GetComponentInChildren<Rigidbody>().velocity = new Vector3(5, 5, 5);
    }

    public void ObjectThrown(Vector3 start, Vector3 end)
    {
        startTime = Time.time;
        StartCoroutine(WaitForCollider());
        beginThrow = start;
        endThrow = end;
        thrown = true;
    }

    IEnumerator WaitForCollider()
    {
        yield return new WaitForSeconds(0.1f);
        col.enabled = true;
    }
}
