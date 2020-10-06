using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndImage : MonoBehaviour
{
    public int mortemax;
    public Texture goodending;
    public Texture badending;
    private deathmanager deathsmanager;
    // Start is called before the first frame update
    void Start()
    {
        deathsmanager = FindObjectOfType<deathmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathsmanager.deaths < mortemax)
        {
            this.GetComponent<RawImage>().texture = goodending;
        }
        else

            this.GetComponent<RawImage>().texture = badending;
    }
    
   
}
