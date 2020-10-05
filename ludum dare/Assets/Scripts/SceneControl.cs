using System.Collections;
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
    void Start()
    {
        audio = GameObject.FindObjectOfType<AudioSource>();
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
        SceneManager.LoadScene(currentscene);
        Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
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
