using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created by Jon 
// Modified by 
public class LoadSceneOnClick : MonoBehaviour {

	public void LoadSceneByIndex(int sceneIndex)
    {
        StartCoroutine("playSound", sceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    //IEnumerator will do the work, while adding a delay after clicking to ensure the sound fully plays
    IEnumerator playSound(int value)
    {
        Debug.Log("Entered Routine");
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(value);
    }
}
