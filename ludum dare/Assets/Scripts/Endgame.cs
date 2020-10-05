using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{
    public int mortemax;
    private bool win;
    public GameObject endPannel;
    public Text Panneltext;
    public GameObject happynico;
    public GameObject sadnico;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Panneltext = endPannel.transform.GetChild(0).GetComponent<Text>();
            if (collision.GetComponent<obtaclemanager>().mortes <= mortemax)
            {
                win = true;
                PauseGame();

                Panneltext.text = "Voce ganhou!!";
                happynico.SetActive(true);

            }
            else
            {
                win = false;
                PauseGame();
                Panneltext.text = "Voce perdeu!!";
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
