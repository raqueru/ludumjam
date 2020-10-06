using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class obtaclemanager : MonoBehaviour
{
 
    public int mortes;
    public GameObject Ghost_Track;
    private GameObject track;
    private deathmanager DeathManager;
    float distancePassed = 5;
    private void Start()
    {
        DeathManager = FindObjectOfType<deathmanager>();

         
        track = Ghost_Track;

    }

    private void Update()
    {
        DeathManager.Deathcounter(DeathManager.contador, DeathManager.deaths);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
           
            DeathManager.deaths++;
           
  
            
           track= Instantiate(Ghost_Track, transform.position, Quaternion.identity); 

        }
    }

   

}
