using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{

    public cameramov cameraScript;

    // Start is called before the first frame update
    void Start()
    {
        cameraScript = FindObjectOfType<cameramov>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 0 || collision.gameObject.layer == 8)
        {

            cameraScript.offset.x = 0;
            cameraScript.moveSpeed = 0;

            Debug.Log("Parei a camera");
        }

    }


}
