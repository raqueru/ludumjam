using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TradeScene : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<playermov>().gameObject;
    }
    private void Update()
    {
      
    
        if (player.transform.position.x > transform.position.x)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
   
}
