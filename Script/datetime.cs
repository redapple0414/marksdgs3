using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう
using System;

public class datetime : MonoBehaviour
{
    public Text time;


    // Start is called before the first frame update
    void Start()
    {
        DateTime now = DateTime.Now;
 
        DateTime tagetDate = new DateTime(2030, 1, 1);
  
        TimeSpan timespan = tagetDate - now;

        time.text = "2030年まであと " + timespan.Days + " 日";
    }
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
    }


}
