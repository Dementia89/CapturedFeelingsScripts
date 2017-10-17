using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Created By Jon

public class DeathMenuController : MonoBehaviour
{
    public Transform canvas;
    public PlayerControls player;

    public Button cpButton, restartButton, mmButton;

    public void Start()
    {
        canvas.gameObject.SetActive(false);
        Button cpbtn = cpButton.GetComponent<Button>();
        Button restartbtn = restartButton.GetComponent<Button>();
        Button mmbtn = mmButton.GetComponent<Button>();

        cpbtn.onClick.AddListener(TaskOnClick);
        restartbtn.onClick.AddListener(TaskOnClick2);
        mmbtn.onClick.AddListener(TaskOnClick3);
        
    }

    void TaskOnClick()
    {
        player.Respawn();
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
    }

    void TaskOnClick2()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    void TaskOnClick3()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
