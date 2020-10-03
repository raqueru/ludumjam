using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class obtaclemanager : MonoBehaviour
{
    public Text contador;
    public int mortes;
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            mortes++;
            Deathcounter(contador, mortes);
           
        }
    }

    void Deathcounter(Text text, int deaths)
    {

        contador.text = "" + deaths;
    }

}
