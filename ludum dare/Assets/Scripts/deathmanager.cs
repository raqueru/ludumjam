using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathmanager : MonoBehaviour
{
    public  int deaths;
    public obtaclemanager deathcounter;
    public static deathmanager Deathmanager;
    private static bool DeathManagerExists;
    public Text contador;

    void Start()
    {
        contador = GameObject.Find("num").GetComponent<Text>();
          
         deathcounter = FindObjectOfType<obtaclemanager>();
        if (!DeathManagerExists) //if GameManagerexcistst is not true --> this action will happen.
        {
            DeathManagerExists = true;
            DontDestroyOnLoad(transform.gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (contador == null)
        {
            contador = GameObject.Find("num").GetComponent<Text>();
        }
    }
    public void Deathcounter(Text text, int deaths)
    {

        contador.text = "" + deaths;
      
    }
    public int getdeaths()
    {
        return deaths ;
    }
     
}
