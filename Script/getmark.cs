using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class getmark : MonoBehaviour
{
     public Text getmarktext;
      int getnumber = 0;
        Chatterscript[] Chatterscripts; 
    // Start is called before the first frame update
    void Start()
    {
           Chatterscripts = GetComponentsInChildren<Chatterscript>();
          for (int i = 0; i < Chatterscripts.Length; i++)
        {
           
            if (Chatterscripts[i].Achievement != 1)
            {
               

            }
            else
            {
                this.getnumber ++;
            }
            if (Chatterscripts[i].Achievement2 != 1)
            {
               

            }
            else
            {
                this.getnumber ++;
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
           
            if (Chatterscripts[i].Achievement != 1)
            {
               

            }
            else
            {
                this.getnumber ++;
            }
            if (Chatterscripts[i].Achievement2 != 1)
            {
               

            }
            else
            {
                this.getnumber ++;
            }
        }
        } 
        getmarktext.text = "ゲットしたマークの数:"+this.getnumber;
    }
}
