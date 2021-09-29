using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
[RequireComponent(typeof(CanvasGroup))]
public class hukidasi : MonoBehaviour
{
   [Multiline]
    public string SpeechEarth1;
   [Multiline]
    public string SpeechEarth2;
    private bool istalking = false;
    GameObject hukidasiText;
    GameObject Childimage;
    GameObject namaeimage;
    GameObject speakmarkimage;
    GameObject speakmarkkimage;
    GameObject hukidasiimage;
   // GameObject Helpimage;
    GameObject Helptext;
    GameObject click;
    public int Achievement = 1;
    public int Achievement2 = 1;
    //GameObject hukidasiObject;
    GameObject HelpName;
    public Sprite none;
    public Sprite earthkun;
    public Sprite earthname;
    public float DurationSeconds;
    public Ease EaseType;
    private CanvasGroup canvasGroup;
   GameObject zukan;
    public void Sethukidasi(string sp,Sprite sprite,Sprite nahuda,bool Get,Sprite speakmark,Sprite speakmarkk)
    {


        if (this.istalking == false)
        {
           // this.Helpimage.SetActive(false);
           

            this.istalking = true;
            this.Childimage.SetActive(true);
          
            //this.hukidasiObject.SetActive(true);
            this.hukidasiText.GetComponent<TextMeshProUGUI>().text = sp;
            this.Childimage.GetComponent<Image>().sprite = sprite;


            //this.hukidasiObject = GameObject.Find("hukidasi");
            Invoke("Help", 7);
            Invoke("Resettalking", 7);
            hukidasiimage.transform.DOScale(new Vector3(0f, 0f, 0f),0f);
            Childimage.transform.DOLocalMove(new Vector3(0, 300, 0), 0f);
            Childimage.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0f);
            Childimage.transform.DOLocalMove(new Vector3(-715, -400, 0), 1f);
            Childimage.transform.DOScale(new Vector3(1, 1, 1), 1f);                         
            hukidasiimage.transform.DOScale(new Vector3(2f, 4f, 1f), 1f)
                                   .SetDelay(1f);
            this.hukidasiimage.SetActive(true);
            //this.hukidasiText.SetActive(true);
            this.namaeimage.SetActive(true);
            this.namaeimage.GetComponent<Image>().sprite = nahuda;
                this.speakmarkimage.GetComponent<Image>().sprite = speakmark;
     
            this.speakmarkkimage.GetComponent<Image>().sprite = speakmarkk;
            Invoke("letspeakmark",2);
            
            if (Get == false)
            {
                  this.canvasGroup = zukan.GetComponent<CanvasGroup>();
    　            this.canvasGroup.DOFade(0.0f, this.DurationSeconds/2).SetEase(this.EaseType).SetLoops(18, LoopType.Yoyo);
    Invoke("MAX", 5);
  
    
            }
            else
            {
             
            }

        }
        
    }
    public void Gethukidasi(string sp)
    {
        
        


        if (this.istalking == false)
        {
           
            this.istalking = true;
            this.hukidasiimage.SetActive(true);
      
            hukidasiimage.transform.localScale = new Vector3(0, 0, 0);

            this.hukidasiText.GetComponent<TextMeshProUGUI>().text = sp;

            


            hukidasiimage.transform.DOScale(new Vector3(2f, 4f, 1f), 1f)
                                   .SetDelay(1f);
 
            Invoke("Resettalking", 7);


        }

    }
    private void Resettalking()
    {
        
        this.istalking = false;
        //this.hukidasiObject.SetActive(false);
        this.Childimage.SetActive(false);
        this.namaeimage.SetActive(false);
        this.speakmarkimage.SetActive(false);
        this.speakmarkkimage.SetActive(false);
      //  this.hukidasiText.SetActive(false);
        this.hukidasiimage.SetActive(false);
        this.Childimage.GetComponent<Image>().sprite = null;
        this.namaeimage.GetComponent<Image>().sprite = null;
         this.speakmarkkimage.GetComponent<Image>().sprite = null;
          this.speakmarkkimage.GetComponent<Image>().sprite = null;
       // this.hukidasiText.GetComponent<Text>().text = null;
       // this.Helpimage.SetActive(false);



    }
    private void Help()
    {


    }
    // Start is called before the first frame update
    void Start()
    {

      
      this.click = GameObject.Find("click");
       this.zukan = GameObject.Find("SceneButton");
        this.hukidasiText = GameObject.Find("ChatterText");
        this.Childimage = GameObject.Find("Speech");
        this.namaeimage = GameObject.Find("nahuda");
         this.speakmarkimage = GameObject.Find("mark");
         this.speakmarkkimage = GameObject.Find("markk");
        this.hukidasiimage = GameObject.Find("hukidasi");
      //  this.Helpimage = GameObject.Find("Help");
        this.Helptext = GameObject.Find("Helptext");
        this.Childimage.SetActive(false);
        //this.hukidasiText.SetActive(false);
        this.hukidasiimage.SetActive(false);
        this.namaeimage.SetActive(false);
         this.speakmarkimage.SetActive(false);
          this.speakmarkkimage.SetActive(false);

       // this.hukidasiText.GetComponent<TextMeshProUGUI>().text = SpeechEarth2;

        this.Childimage.GetComponent<Image>().sprite = null;
       // this.hukidasiText.GetComponent<Text>().text = null;
        //  this.Helptext.GetComponent<Text>().text = null;
       // this.Helpimage.SetActive(false);
       // this.Helpimage.SetActive(false);


       
        this.Childimage.SetActive(true);

        

        //this.hukidasiObject.SetActive(true);
 
        this.Childimage.GetComponent<Image>().sprite = earthkun;
        this.Childimage.transform.localScale = new Vector3(1.5f, 1.5f, 0.1f);

        //this.hukidasiObject = GameObject.Find("hukidasi");
        Invoke("Help", 5);
        Invoke("Resettalking", 5);
     
     if(PlayerPrefs.GetInt("Clear") != 1)
        {
           this.hukidasiText.GetComponent<TextMeshProUGUI>().text = SpeechEarth1;
          // this.hukidasiText.SetActive(false);
        }
        else
        {
        this.hukidasiText.GetComponent<TextMeshProUGUI>().text = SpeechEarth1;
        }

       // this.hukidasiText.GetComponent<TextMeshProUGUI>().text = SpeechEarth1;
        hukidasiimage.transform.DOScale(new Vector3(0f, 0f, 0f), 0.1f);
        Childimage.transform.DOLocalMove(new Vector3(0, 300, 0), 0.1f);
        Childimage.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f);
        Childimage.transform.DOLocalMove(new Vector3(-715, -400, 0), 0.1f);
        Childimage.transform.DOScale(new Vector3(1.65f, 1.65f, 1), 0.1f);
        hukidasiimage.transform.DOScale(new Vector3(2f, 4f, 1f), 0.1f)
                               .SetDelay(0f);
        this.hukidasiimage.SetActive(true);
        //this.hukidasiText.SetActive(true);
        this.namaeimage.SetActive(true);
        this.namaeimage.GetComponent<Image>().sprite = earthname;
      //  this.Helpimage.GetComponent<Image>().sprite = earthname;

    }

    // Update is called once per frame
    void Update()
    {
//  if (Input.GetMouseButtonDown(0))
//         　  {
//             this.istalking = false;
//         //this.hukidasiObject.SetActive(false);
//         this.Childimage.SetActive(false);
//         this.namaeimage.SetActive(false);
//       //  this.hukidasiText.SetActive(false);
//         this.hukidasiimage.SetActive(false);
//         this.Childimage.GetComponent<Image>().sprite = null;
//         this.namaeimage.GetComponent<Image>().sprite = null;
//        // this.hukidasiText.GetComponent<Text>().text = null;
//        // this.Helpimage.SetActive(false);

//           　 }
    }
    private void MAX()
    {
      canvasGroup.DOFade(1.0f,1);
    }
     public void letspeakmark()
    {
      Debug.Log("dekiruyanaikai");
         this.speakmarkimage.SetActive(true);
        
             this.speakmarkkimage.SetActive(true);
           
    }
}

