using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarBreaker : MonoBehaviour
{
    private GameObject Jar;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Jar = GameObject.Find("JarAngry(Clone)");

        if (other.tag == "Player")
        {
            Jar.GetComponent<BreakImp>().BestowFeeling(Emotion.Angry);
        }
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    Jar = GameObject.Find("JarAngry(Clone)");

    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Jar.GetComponent<Break>().BreakJar();
    //    }
    //}
}
