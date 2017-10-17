using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created by Jon

public class CollectibleMenu : MonoBehaviour
{
    public Transform canvas;
    public Button button;
    public bool isActivated = false;
    bool hasBeenActivated = false;
    //public KeyCode key;

    void Start()
    {
        Button btn = button.GetComponent<Button>();

        btn.onClick.AddListener(Close);

        canvas.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    void Update()
    {
        if (!hasBeenActivated)
        {
            if (isActivated)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                hasBeenActivated = true;
            }
        }
    }

    public void Close()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}