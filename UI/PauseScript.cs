
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Created by Jon

public class PauseScript : MonoBehaviour
{
    public Transform canvas;
    public Transform pauseMenu;
    public Transform optionsMenu;
    public Transform creditsMenu;
    public Transform Player;

    public Button resumeButton, creditsButton, optionsButton, backButton1, backButton2;

    public void Start()
    {
        canvas.gameObject.SetActive(false);
        Button resbtn = resumeButton.GetComponent<Button>();
        Button credbtn = creditsButton.GetComponent<Button>();
        Button optbtn = optionsButton.GetComponent<Button>();
        Button backbtn1 = backButton1.GetComponent<Button>();
        Button backbtn2 = backButton2.GetComponent<Button>();

        resbtn.onClick.AddListener(TaskOnClick);
        optbtn.onClick.AddListener(TaskOnClick2);
        credbtn.onClick.AddListener(TaskOnClick3);
        backbtn1.onClick.AddListener(TaskOnClick4);
        backbtn2.onClick.AddListener(TaskOnClick4);    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.gameObject.SetActive(true);
                optionsMenu.gameObject.SetActive(false);
                creditsMenu.gameObject.SetActive(false);
            }
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            
        }
    }

    void TaskOnClick()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void TaskOnClick2()
    {
        pauseMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(true);
        creditsMenu.gameObject.SetActive(false);
    }

    void TaskOnClick3()
    {
        pauseMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        creditsMenu.gameObject.SetActive(true);
    }

    void TaskOnClick4()
    {
        pauseMenu.gameObject.SetActive(true);
        optionsMenu.gameObject.SetActive(false);
        creditsMenu.gameObject.SetActive(false);
    }

}


















//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class PauseScript : MonoBehaviour
//{
//    public Transform canvas;
//    public Button resumeButton;//, creditsButton, optionsButton, backButton1, backButton2;
//    public GameObject[] credits, options, pause;
//    public int optSize, credSize, pauseSize;
//    public KeyCode key;

//    void Start()
//    {
//        Button resbtn = resumeButton.GetComponent<Button>();
//        Button credbtn = creditsButton.GetComponent<Button>();
//        Button optbtn = optionsButton.GetComponent<Button>();
//        Button backbtn1 = backButton1.GetComponent<Button>();
//        Button backbtn2 = backButton2.GetComponent<Button>();

//        resbtn.onClick.AddListener(TaskOnClick);
//        backbtn1.onClick.AddListener(TaskOnClick2);
//        backbtn2.onClick.AddListener(TaskOnClick2);
//        credbtn.onClick.AddListener(TaskOnClick3);
//        optbtn.onClick.AddListener(TaskOnClick4);

//        canvas.gameObject.SetActive(false);

//        Time.timeScale = 1;


//        options = new GameObject[optSize];
//        credits = new GameObject[credSize];
//        credits = new GameObject[pauseSize];
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(key))
//        {
//            if (canvas.gameObject.activeInHierarchy == false)
//            {
//                canvas.gameObject.SetActive(true);
//                Time.timeScale = 0;
//                foreach (GameObject go1 in options)
//                {
//                    go1.gameObject.SetActive(false);
//                }
//                foreach (GameObject go1 in credits)
//                {
//                    go1.gameObject.SetActive(false);
//                }
//            }
//            else
//            {
//                canvas.gameObject.SetActive(false);
//                foreach (GameObject go1 in options)
//                {
//                    go1.gameObject.SetActive(false);
//                }
//                foreach (GameObject go1 in credits)
//                {
//                    go1.gameObject.SetActive(false);
//                }
//                Time.timeScale = 1;
//            }
//        }
//    }


//    void TaskOnClick()
//    {
//        canvas.gameObject.SetActive(false);
//        Time.timeScale = 1;
//    }

//    void TaskOnClick2()
//    {
//        foreach (GameObject go in options)
//        {
//            go.gameObject.SetActive(false);
//        }
//        foreach (GameObject go in credits)
//        {
//            go.gameObject.SetActive(false);
//        }
//        foreach (GameObject go in pause)
//        {
//            go.gameObject.SetActive(true);
//        }
//    }

//    void TaskOnClick3()
//    {
//        foreach (GameObject go in pause)
//        {
//            go.gameObject.SetActive(false);
//        }
//        foreach (GameObject go in options)
//        {
//            go.gameObject.SetActive(true);
//        }
//    }

//    void TaskOnClick4()
//    {
//        foreach (GameObject go in credits)
//        {
//            go.gameObject.SetActive(true);
//        }
//        foreach (GameObject go in pause)
//        {
//            go.gameObject.SetActive(false);
//        }
//    }
//}

