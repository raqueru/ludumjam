using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneActiave : MonoBehaviour
{
    public PlayableDirector cutscene;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cutscene.gameObject.SetActive(true);
            cutscene.Play();
        }
    }
}
