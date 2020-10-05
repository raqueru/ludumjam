using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obtaclemanager : MonoBehaviour
{
    private Text contador;
    public int mortes;
    public GameObject Ghost_Track;
    private GameObject track;
    private deathmanager DeathManager;
    float distancePassed = 5;
    private void Start()
    {
        DeathManager = FindObjectOfType<deathmanager>();
     

        contador = GameObject.Find("num").GetComponent<Text>();
        track = Ghost_Track;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            DeathManager.deaths++;
  
            Deathcounter(contador, mortes);
           track= Instantiate(Ghost_Track, transform.position, Quaternion.identity); 

        }
    }

    void Deathcounter(Text text, int deaths)
    {

        contador.text = "" + DeathManager.deaths;
    }

}
