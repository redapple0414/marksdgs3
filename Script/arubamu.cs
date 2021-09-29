using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class arubamu : MonoBehaviour
{
   
    public void Loadphoto(string markName)
    {
       var texture = new Texture2D(1, 1);
       string enc = PlayerPrefs.GetString("textShot" + markName);
       byte[] bytes = System.Convert.FromBase64String(enc);

       texture.LoadImage(bytes);

       // Image内に割り当てられたスクリプト内なら下記を呼ぶだけ。
       GetComponent<Image>().material.mainTexture = texture;
       // Texture2D TEX = CameraScreenShotCapturer.LoadJPGorPNG(FileName);
       
       // Debug.Log(TEX);
       // Sprite sprite = Sprite.Create(TEX, new Rect(0, 0, TEX.width, TEX.height), Vector2.zero);
       // GetComponent<Image>().sprite = sprite;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
