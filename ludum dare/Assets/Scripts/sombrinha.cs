using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sombrinha : MonoBehaviour
{

    public GameObject myDad;
    Transform myTransform;

    [SerializeField]
    Vector3 initialDadTransform;


    public Vector3 scaleToGo;
    public Vector3 scaleOriginal;


    // Start is called before the first frame update
    void Start()
    {
        myDad = transform.parent.gameObject;
        initialDadTransform = myDad.transform.position;
        myTransform = GetComponent<Transform>();
    }
        // Update is called once per frame
     void FixedUpdate()
     {
        Vector3 dadNewTransform = myDad.transform.position;

        LocalPositionY(dadNewTransform);

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

    void LocalPositionY(Vector3 dadNewTransform)
    {
        Vector3 differenceDad = (dadNewTransform - initialDadTransform);
        float newY = -differenceDad.y * 2;

        if (dadNewTransform.y > initialDadTransform.y + 1)
        { 
            myTransform.localPosition = new Vector3(0,newY, 0);
        }
        else if (myTransform.localPosition.y >= -2)
        {
            myTransform.localPosition = new Vector3(0, -2, 0);
        }

    }
}

