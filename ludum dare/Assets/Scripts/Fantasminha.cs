using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasminha : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Yameteee");
            Destroy(this.gameObject,5);
        }
    }
}
