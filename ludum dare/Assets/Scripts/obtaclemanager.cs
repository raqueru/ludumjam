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
    float distancePassed = 5;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        contador = GameObject.Find("num").GetComponent<Text>();
        track = Ghost_Track;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            mortes++;
            Deathcounter(contador, mortes);
           track= Instantiate(Ghost_Track, transform.position, Quaternion.identity); 

        }
    }

    void Deathcounter(Text text, int deaths)
    {

        contador.text = "" + deaths;
    }

}
