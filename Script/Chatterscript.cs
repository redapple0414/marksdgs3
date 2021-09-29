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

    public static string selectmarkname;

    public bool Get;
    public void Sethukidasi()
    {
       


        if (this.ookisa.x <= this.transform.localScale.x)
        {
            if (this.Achievement > 0 || this.Achievement2 > 0)
            {
                
                Invoke("Help", 2.0001f);
                this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;
                Debug.Log(hukidasi.GetComponent<hukidasi>());
                Debug.Log(GetComponent<SpriteRenderer>().sprite);
                this.Get = true;
                this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp2, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speakmark,speakmarkk);
           
            }
            else
            {
                
                this.hukidasi = GameObject.Find("Canvas").transform.Find("hukidasi").gameObject;            
                Debug.Log(hukidasi.GetComponent<hukidasi>());
                Debug.Log(GetComponent<SpriteRenderer>().sprite);
                this.Get = false;
                this.hukidasi.GetComponent<hukidasi>().Sethukidasi(sp, GetComponent<SpriteRenderer>().sprite, nahuda,Get,speakmark,speakmarkk);
                int foundMarkCount = PlayerPrefs.GetInt(markName);
                int foundMarkCount2 = PlayerPrefs.GetInt(markName2);

                foundMarkCount = -1;
                foundMarkCount2 = -1;

                PlayerPrefs.SetInt(markName, foundMarkCount);
                PlayerPrefs.SetInt(markName2, foundMarkCount2);
            }
        }
        
    }

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
    }
    private void Help()
    {

    }
}
