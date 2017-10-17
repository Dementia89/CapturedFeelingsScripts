using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenJarRemoval : MonoBehaviour
{
    MeshCollider[] meshColliders;

    private void Start()
    {
        meshColliders = GetComponentsInChildren<MeshCollider>();
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(5);
        foreach(MeshCollider mc in meshColliders)
        {
            mc.enabled = false;
        }
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
