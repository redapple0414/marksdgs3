using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class earthCamera: MonoBehaviour
{ 
  public int Achievement = 1;
  public int Achievement2 = 1;
  Image MainImage;
  public float DurationSeconds;
  public Ease EaseType;
  GameObject hukidasiText;
　 GameObject Childimage;
  GameObject namaeimage;
  GameObject speakmarkimage;
  GameObject speakmarkkimage;
  GameObject hukidasiimage;
  GameObject Canvas;
   // GameObject Helpimage;
    GameObject Helptext;
    GameObject click;
 　　private CanvasGroup canvasGroup;
    GameObject oya;

    public static string scene;
    public void Camera()
    {
        Canvas.transform.Find("World Population").gameObject.SetActive(false);
            Canvas.transform.Find("2030").gameObject.SetActive(false);
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

        GameObject objGet;
        Camerascreen.scene = "Camera";
        oya = GameObject.Find("Main Camera");
        objGet = GameObject.Find("Book(Clone)");
        Destroy(objGet);
          objGet = GameObject.Find("Book2(Clone)");
        Destroy(objGet);
        if (oya.transform.Find("AICamera(Clone)") == null)
        {

            GameObject obj5 = (GameObject)Resources.Load("AICamera");
            GameObject obj6 = Instantiate(obj5, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
            obj6.transform.parent = oya.transform;
        }
        else
        {
            oya.transform.Find("AICamera(Clone)").gameObject.SetActive(true);

        }
    }

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        this.hukidasiText = GameObject.Find("ChatterText");
        this.Childimage = GameObject.Find("Speech");
        this.namaeimage = GameObject.Find("nahuda");
        this.speakmarkimage = GameObject.Find("mark");
        this.speakmarkkimage = GameObject.Find("markk");
        this.hukidasiimage = GameObject.Find("hukidasi");
      //  this.Helpimage = GameObject.Find("Help");
        this.Helptext = GameObject.Find("Helptext");
   
       　MainImage = gameObject.GetComponent<Image>();

 　　　　this.canvasGroup = this.GetComponent<CanvasGroup>();
    　　this.canvasGroup.DOFade(0.0f, this.DurationSeconds).SetEase(this.EaseType).SetLoops(-1, LoopType.Yoyo);
     　Invoke("MAX", 5);
     
    }
    

    void Update()
    {
         Achievement = PlayerPrefs.GetInt(Chatterscript.selectmarkname);
     Debug.Log(Chatterscript.selectmarkname);
     if (this.Achievement > 0)
        {
           
           
            MainImage.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 255 / 225.0f);
        }
    
        else
        {
          
          
            MainImage.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 255 / 125.5f);
        }
    }
    
    private void MAX()
    {
      canvasGroup.DOFade(1.0f,1);
    }
	
}
