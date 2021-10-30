using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class helpmark : MonoBehaviour
{ 
    public Text helpmarktext;
    int helpnumber = 0;
      Chatterscript[] Chatterscripts; 
    // Start is called before the first frame update
    void Start()
    {
           Chatterscripts = GetComponentsInChildren<Chatterscript>();
         for (int i = 0; i < Chatterscripts.Length; i++)
        {
           
            if (Chatterscripts[i].Achievement != 1 && Chatterscripts[i].Achievement2 != 1)
            {
                
             
               

            }
            else
            {
 this.helpnumber ++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
  if (Input.GetMouseButtonDown(0))
        {
               Chatterscripts = GetComponentsInChildren<Chatterscript>();
         for (int i = 0; i < Chatterscripts.Length; i++)
        {
           
            if (Chatterscripts[i].Achievement != 1 && Chatterscripts[i].Achievement2 != 1)
            {
                
             
               

            }
            else
            {
 this.helpnumber ++;
            }
        }
        }
        helpmarktext.text = "助けた子供の数:"+this.helpnumber;
    }
}
