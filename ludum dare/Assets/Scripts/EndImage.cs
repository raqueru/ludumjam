using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndImage : MonoBehaviour
{
    private Endgame end;
    public Texture goodending;
    public Texture badending;
    private deathmanager deathsmanager;
    // Start is called before the first frame update
    void Start()
    {
        deathsmanager = FindObjectOfType<deathmanager>();
        end= FindObjectOfType<Endgame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathsmanager.deaths < end.mortes)
        {
            this.GetComponent<RawImage>().texture = goodending;
        }
        else

            this.GetComponent<RawImage>().texture = badending;
    }
    
   
}
