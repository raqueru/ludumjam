using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasminha : MonoBehaviour
{

    public playermov Player;
    //public Vector2 playerPosition;
    Vector2 myPosition;

    [SerializeField]
    float distancePassed = 5;


    void Start()
    {
        myPosition = new Vector2(transform.position.x, transform.position.y);

        Player = GameObject.FindObjectOfType<playermov>();

    }


    void Update()
    {

        if (Player.transform.position.x > myPosition.x + distancePassed)
        {
            Destroy(this.gameObject);
        }

    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Yameteee");
            Destroy(this.gameObject,5);
        }
    }*/
}
