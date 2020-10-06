using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneActiave : MonoBehaviour
{
    public PlayableDirector cutscene;
    private GameObject player;
    private bool end=false;

    private void Start()
    {
        player = FindObjectOfType<playermov>().gameObject;
    }
    private void Update()
    {


        if (player.transform.position.x > transform.position.x)
            if (!end)
            {
                cutscene.gameObject.SetActive(true);
                cutscene.Play();
                end = true;
            }
        }

    }

