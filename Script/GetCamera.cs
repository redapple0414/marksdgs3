using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
public class GetCamera : MonoBehaviour
{

    public int Achievement = 1;

    public string markName;
GameObject torinaosi;
  
    GameObject photo;
 　 GameObject camerawaku;
    Image MainImage;
    GameObject batu;

    public Sprite Camera;
    public Sprite Camera2;
    //GameObject hukidasiObject;
    void Start()
    {
        this.torinaosi = GameObject.Find("torinaosi");
        this.photo = GameObject.Find("photo");
        this.batu = GameObject.Find("batu2");
        this.camerawaku = GameObject.Find("camerawaku");
        Achievement = PlayerPrefs.GetInt(markName);
        
        MainImage = gameObject.GetComponent<Image>();
    }
    public void SetCamera(Sprite sprite)
    {  
        this.torinaosi = GameObject.Find("torinaosi");
        this.photo = GameObject.Find("photo");
        this.batu = GameObject.Find("batu2");
        this.camerawaku = GameObject.Find("camerawaku");
        photo.GetComponent<arubamu>().Loadphoto(markName);
         torinaosi.GetComponent<torinaosi>().Loadcamera(markName);
        this.photo.GetComponent<Image>().enabled = true;
        this.batu.GetComponent<Image>().enabled = true;
        this.camerawaku.GetComponent<Image>().enabled = true;
          this.torinaosi.GetComponent<Image>().enabled = true;
        camerawaku.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0f);
        camerawaku.transform.DOScale(new Vector3(18, 28, 1), 0.5f);
        photo.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0f);
        photo.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
         batu.transform.DOScale(new Vector3(0, 0, 1), 0f);
        batu.transform.DOScale(new Vector3(0.5f,0.27f, 0.1f), 0.5f);
           torinaosi.transform.DOScale(new Vector3(0, 0, 1), 0f);
        torinaosi.transform.DOScale(new Vector3(0.5f,0.27f, 0.1f), 0.5f);
       
        

    }
    private void Update()
    {
        if (this.Achievement >= 1)
        {
            MainImage.sprite = Camera;
        }
        else
        {
            MainImage.sprite = Camera2;
        }

    }
}
