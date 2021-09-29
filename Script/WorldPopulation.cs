using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class WorldPopulation: MonoBehaviour
{
    DateTime baseTime = new DateTime(2021,06,19,13,11,0);
    long Population = 7830885325;
    public Text Worldtext;
    // Start is called before the first frame update
    void Start()
    {
        Worldtext.text = "�l";
    }

    // Update is called once per frame
    void Update()
    {
        if (Camerascreen.scene == "earth")
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(1000, 50);
        }
        else
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(0, 0);
        }
        TimeSpan span = DateTime.Now - baseTime;
        long populationcount = Population + (long)(span.Seconds * 2.4f);
        //Debug.Log(populationcount);
        //Debug.Log(span.TotalSeconds * 2.4f);
        string Populationtext = (Population + (int)(span.TotalSeconds * 2.4f)).ToString();
        Worldtext.text = "世界の人口:"+Populationtext.Substring(0,2)+"億" + Populationtext.Substring(2,4) + "万" + Populationtext.Substring(6,4) + "人";
    }
}
