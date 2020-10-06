using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{
    private bool win;
    public GameObject endPannel;
    public GameObject cutscene;
    public Text Panneltext;
    public GameObject happynico;
    public GameObject sadnico;
    public deathmanager deathsss;
    public int mortes;
    private GameObject player;

    private void Start()
    {
        deathsss = FindObjectOfType<deathmanager>();

        player = FindObjectOfType<playermov>().gameObject;
    }


   void Update()  
    {
        if (player.transform.position.x>transform.position.x)
        {
            cutscene.SetActive(false);
            Panneltext = endPannel.transform.GetChild(0).GetComponent<Text>();
            if (deathsss.deaths<mortes )
            {
                win = true;
                PauseGame();

                Panneltext.text = "You won!";
                happynico.SetActive(true);

            }
            else
            {
                win = false;
                PauseGame();
                Panneltext.text = "You lost...";
                sadnico.SetActive(true);
            }
            }
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        endPannel.SetActive(true);
       
    }
}
