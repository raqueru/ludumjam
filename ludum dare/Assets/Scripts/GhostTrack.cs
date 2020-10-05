using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrack : MonoBehaviour
{
    private GameObject Ghost_Track;
    private GameObject Player;
    float distancePassed = 10;
    private void Start()
    {
        Player = FindObjectOfType<playermov>().gameObject;
    }
    void Update()
    {

        if (Player.transform.position.x > transform.position.x + distancePassed)
        {
            Destroy(this.gameObject);
        }

    }
}
