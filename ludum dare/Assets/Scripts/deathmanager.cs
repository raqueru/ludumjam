using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathmanager : MonoBehaviour
{
    public int deaths;
    public obtaclemanager deathcounter;
    public static deathmanager Deathmanager;
    private static bool DeathManagerExists;
    void Start()
    {
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

}
