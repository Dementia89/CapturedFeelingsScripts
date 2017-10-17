using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created by Jon

public class LoadSceneOnCollision : MonoBehaviour
{

    public Transform player;
    
    public int sceneIndex;

    GameObject LoadingScreen;

    private void Start()
    {
        LoadingScreen = GameObject.FindGameObjectWithTag("LoadScreen");
        LoadingScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(sceneIndex);
    }

    
}
