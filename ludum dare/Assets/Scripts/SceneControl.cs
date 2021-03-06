﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public GameObject pausebox;
    private bool paused;
    private AudioSource audio;
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button but;
    public deathmanager deathManager;
    void Start()
    {
        audio = GameObject.FindObjectOfType<AudioSource>();
        deathManager = FindObjectOfType<deathmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            restartgame();
        }
        PauseGame();
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if(!paused)
        {
            pausebox.SetActive(true);
            Time.timeScale = 0;
            paused = true;

        }
            else{
                pausebox.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
    }
    public void restartgame()
    {
        string currentscene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(0);

        Time.timeScale = 1;
        deathManager.deaths = 0;
    }
    

    public void audiomute()
    {
        if (!audio.mute)
            but.image.sprite = OffSprite;
        else
        {
            but.image.sprite = OnSprite;
        }
        audio.mute = !audio.mute;
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
