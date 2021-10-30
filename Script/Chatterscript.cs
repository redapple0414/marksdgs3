using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Chatterscript : MonoBehaviour
{
    [Multiline]
    public string sp;
    [Multiline]
    public string sp2;
    public int Achievement = 1;
    public int Achievement2 = 1;
    GameObject hukidasi;
    public Vector3 ookisa = new Vector3(0.3f, 0.3f, 1);
    SpriteRenderer SpriteRenderer;
    public Sprite Child;
    public Sprite Child2;
    public string markName;
    public string markName2;
    public Sprite nahuda;
    public Sprite speakmark;
    public Sprite speakmarkk;
      public Sprite speak;
    public Sprite speakk;

    public static string selectmarkname;
public static string selectmarknameing;
    public bool Get;
    // public void Sethukidasi()
    // {
       


    //     if (this.ookisa.x <= this.transform.localScale.x)
    //     {
    //         Chatterscript.selectmarkname = markName;
    //         Chatterscript.selectmarknameing = markName2;

    //         if (this.Achievement > 0 && this.Achievement2 > 0)
    //         {
                
    //           //  Invoke("Help", 2.0001f);
    //             this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;
    //             Debug.Log(hukidasi.GetComponent<hukidasi>());
    //             Debug.Log(GetComponent<SpriteRenderer>().sprite);
    //             this.Get = true;
    //             this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp2, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speakmark,speakmarkk);
           
    //         }
    //         else if (this.Achievement < 1 && this.Achievement2 > 0)
    //         {
                
    //           // Invoke("Help", 2.0001f);
    //             this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;
    //             Debug.Log(hukidasi.GetComponent<hukidasi>());
    //             Debug.Log(GetComponent<SpriteRenderer>().sprite);
    //             this.Get = true;
    //             this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp2, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speak,speakmarkk);
           
    //         }
    //         else if (this.Achievement >0 && this.Achievement2 < 1)
    //         {
                
    //           //  Invoke("Help", 2.0001f);
    //             this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;
    //             Debug.Log(hukidasi.GetComponent<hukidasi>());
    //             Debug.Log(GetComponent<SpriteRenderer>().sprite);
    //             this.Get = true;
    //             this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp2, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speakmark,speakk);
           
    //         }
    //         else
    //         {
                
    //             this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;            
    //             Debug.Log(hukidasi.GetComponent<hukidasi>());
    //             Debug.Log(GetComponent<SpriteRenderer>().sprite);
    //             this.Get = false;
    //             this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speak,speakk);
    //             int foundMarkCount = PlayerPrefs.GetInt(markName);
    //             int foundMarkCount2 = PlayerPrefs.GetInt(markName2);

    //             foundMarkCount = -1;
    //             foundMarkCount2 = -1;

    //             PlayerPrefs.SetInt(markName, foundMarkCount);
    //             PlayerPrefs.SetInt(markName2, foundMarkCount2);
    //         }
    //     }
        
    // }

    void Start()
    {
        
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        Achievement = PlayerPrefs.GetInt(markName);
        Achievement2 = PlayerPrefs.GetInt(markName2);


    }

 
    void Update()
    {
        Achievement = PlayerPrefs.GetInt(markName);
        Achievement2 = PlayerPrefs.GetInt(markName2);

           if (this.Achievement > 0 || this.Achievement2 > 0)
            {

            SpriteRenderer.sprite = Child;
        }
        else
        {
            SpriteRenderer.sprite = Child2;
        }
        if(earth.katikati == 1)
        {
           Debug.Log("とおったよ１");
          if (this.ookisa.x <= this.transform.localScale.x)
         {
            Chatterscript.selectmarkname = markName;
            Chatterscript.selectmarknameing = markName2;
  Debug.Log("とおったよ２");
            if (this.Achievement > 0 && this.Achievement2 > 0)
            {
                
                //Invoke("Help", 2.0001f);
                this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;
                Debug.Log(hukidasi.GetComponent<hukidasi>());
                Debug.Log(GetComponent<SpriteRenderer>().sprite);
                this.Get = true;
                this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp2, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speakmark,speakmarkk);
           
            }
            else if (this.Achievement < 1 && this.Achievement2 > 0)
            {
                
               // Invoke("Help", 2.0001f);
                this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;
                Debug.Log(hukidasi.GetComponent<hukidasi>());
                Debug.Log(GetComponent<SpriteRenderer>().sprite);
                this.Get = true;
                this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp2, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speak,speakmarkk);
           
            }
            else if (this.Achievement >0 && this.Achievement2 < 1)
            {
                
                //Invoke("Help", 2.0001f);
                this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;
                Debug.Log(hukidasi.GetComponent<hukidasi>());
                Debug.Log(GetComponent<SpriteRenderer>().sprite);
                this.Get = true;
                this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp2, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speakmark,speakk);
           
            }
            else
            {
                
                this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;            
                Debug.Log(hukidasi.GetComponent<hukidasi>());
                Debug.Log(GetComponent<SpriteRenderer>().sprite);
                this.Get = false;
                this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speak,speakk);
                int foundMarkCount = PlayerPrefs.GetInt(markName);
                int foundMarkCount2 = PlayerPrefs.GetInt(markName2);

                foundMarkCount = -1;
                foundMarkCount2 = -1;

                PlayerPrefs.SetInt(markName, foundMarkCount);
                PlayerPrefs.SetInt(markName2, foundMarkCount2);
            }
            
         }
        }
        
    }
    private void Help()
    {

    }
}
