using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class skyColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DateTime now = DateTime.Now;
        if (8 <= now.Hour && now.Hour < 17)
        {
            GetComponent<Camera>().backgroundColor = noon; 
        }
        else if (16 <= now.Hour && now.Hour < 19)
        {
            GetComponent<Camera>().backgroundColor = evening;
        }
        else if ((19 <= now.Hour && now.Hour < 21)||(3 <= now.Hour && now.Hour < 5))
        {
            GetComponent<Camera>().backgroundColor = night;
        }
        else if (21 <= now.Hour && now.Hour < 3)
        {
            GetComponent<Camera>().backgroundColor = midnight;
        }
        else
        {
            GetComponent<Camera>().backgroundColor = morning;
        }

    }
    public Color noon;
    public Color evening;
    public Color night;
    public Color midnight;
    public Color morning;

    // Update is called once per frame
    void Update()
    {
        
    }
}
