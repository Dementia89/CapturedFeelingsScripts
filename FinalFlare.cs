using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFlare : MonoBehaviour
{
    public Light flare;

    // Use this for initialization
    void Start()
    {
        flare.intensity = 0;
        flare.range = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            flare.intensity = Mathf.Lerp(0, 75, Time.deltaTime / 10);
            flare.range = Mathf.Lerp(0, 25, Time.deltaTime / 10);
        }
    }
}
