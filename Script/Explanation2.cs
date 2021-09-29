using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;
public class Explanation2 : MonoBehaviour
{

    public int Achievement = 1;

    public string markName;
    GameObject batu;
    GameObject Explanationimage;
   
    public Sprite Explanationimage1;
    public Sprite Explanationimage2;
    public Sprite HatenaExplanation;
    Image MainImage;

  


    //GameObject hukidasiObject;
    void Start()
    {
        Achievement = PlayerPrefs.GetInt(markName);

        this.batu = GameObject.Find("batu");
        this.Explanationimage = GameObject.Find("Explanation");
       


        this.Explanationimage.GetComponent<Image>().sprite = null;
        MainImage = gameObject.GetComponent<Image>();
        if (this.Achievement == 0)
        {
            MainImage.sprite = Explanationimage2;
            MainImage.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 255 / 225.0f);
        }
        
        else
        {
            MainImage.sprite = Explanationimage1;
            MainImage.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 255 / 125.5f);
        }

    }
    public void SetExplanation(Sprite sprite)
    {
        Achievement = PlayerPrefs.GetInt(markName);

   
        this.Explanationimage = GameObject.Find("Explanation");
       
        if (this.Achievement == 0 || this.Achievement == -1)
        {
            MainImage.sprite = Explanationimage2;

         //   SceneManager.LoadScene("Camerascreen");
        }
        else
        {
            MainImage.sprite = Explanationimage1;
            this.Explanationimage.GetComponent<Image>().enabled = true;
           
            this.batu.GetComponent<Image>().enabled = true;


            //this.hukidasiObject.SetActive(true);

            this.Explanationimage.GetComponent<Image>().sprite = sprite;

            //this.hukidasiObject = GameObject.Find("hukidasi");
            Explanationimage.transform.DOLocalMove(new Vector3(0, 400, 0), 0f);
            Explanationimage.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        }
    }
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (this.Achievement == 0)
        {
            this.transform.Find("GetCamera").gameObject.SetActive(false);
            this.transform.Find("camera").gameObject.SetActive(false);
            MainImage.sprite = HatenaExplanation;
            MainImage.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 255 / 225.0f);
        }
        else if (this.Achievement == -1)
        {
            this.transform.Find("GetCamera").gameObject.SetActive(false);
            this.transform.Find("camera").gameObject.SetActive(true);
            MainImage.sprite = Explanationimage2;
            MainImage.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 50 / 250.0f);
        }
        else
        {
            this.transform.Find("GetCamera").gameObject.SetActive(true);
            this.transform.Find("camera").gameObject.SetActive(false);
            MainImage.sprite = Explanationimage1;
            MainImage.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 255 / 125.5f);
        }
    }
}
