using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaredSpawnerImp : MonoBehaviour
{
    public GameObject[] spawnables;
    public float spawnSpeed = 0.2f;
    BoxCollider col;
    // Use this for initialization
    void Start()
    {
        col = GetComponent<BoxCollider>();
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(spawnSpeed);
        GameObject spawned = Instantiate(spawnables[Random.Range(0, spawnables.Length)], new Vector3(Random.Range(-col.bounds.extents.x, col.bounds.extents.x) + gameObject.transform.position.x, 
            gameObject.transform.position.y, Random.Range(-col.bounds.extents.z, col.bounds.extents.z) + gameObject.transform.position.z), Random.rotation);
        //GameObject spawned = Instantiate(spawnables[Random.Range(0, spawnables.Length)], new Vector3(gameObject.transform.position.x + Random.Range(-7f, 7f), gameObject.transform.position.y, gameObject.transform.position.z
        //+ Random.Range(-1f, 1f)), Random.rotation);

        spawned.AddComponent<CollisionManager>();
        spawned.AddComponent<BrokenJarRemoval>();
        StartCoroutine(SpawnObject());
    }
}
