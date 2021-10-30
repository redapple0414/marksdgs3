using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Barracuda;
using UnityEngine.SceneManagement;
using System.Text;
using System;
public class gettext : MonoBehaviour
{
    public static int textonoff = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onoff()
    {
     if(gettext.textonoff == 0)
     {
      gettext.textonoff = 1;
     }   
     else
     {
      gettext.textonoff = 0;      
     }
    }
}
