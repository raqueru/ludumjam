using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sombrinha : MonoBehaviour
{

    public GameObject myDad;
    Transform myTransform;


    public Vector3 scaleToGo;
    public Vector3 scaleOriginal;


    // Start is called before the first frame update
    void Start()
    {
        
        myDad = transform.parent.gameObject;
        myTransform = GetComponent<Transform>();
    }
        // Update is called once per frame
     void FixedUpdate()
     {
        if (myDad.transform.tag == "Player")
        {
            if (myDad.layer == 8)
            {
                StartCoroutine(LerpScaleUp(scaleToGo, .1f));
            }
            else if (myDad.layer == 0)
            {
                StartCoroutine(LerpScaleOriginal(scaleOriginal, .1f));
            }
        }

        if(myDad.transform.tag == "Obstacle")
        {
            if(myDad.layer == 8)
            {
                myTransform.localScale = new Vector3(.4f, .4f, 1);
            } 
            else
            {
                myTransform.localScale = new Vector3(.6f, .6f, 1);
            }

        }

        
     }

    IEnumerator LerpScaleUp(Vector3 targetScale, float duration)
    {
        float time = 0;
        Vector3 initialScalePlayer = myTransform.localScale;

        while (time < duration)
        {
            myTransform.localScale = Vector3.Lerp(initialScalePlayer, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        myTransform.localScale = targetScale;
    }

    IEnumerator LerpScaleOriginal(Vector3 targetScaleDown, float duration)
    {
        float time = 0;
        Vector3 initialScalePlayer = myTransform.localScale;

        while (time < duration)
        {
            myTransform.localScale = Vector3.Lerp(initialScalePlayer, targetScaleDown, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        myTransform.localScale = targetScaleDown;
    }
}

