using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneButton : MonoBehaviour
{
    Image image;
    GameObject objGet;

    public Sprite earth;
    public Sprite Picturebook;
    GameObject oya;
    GameObject Canvas;
    public static int pushtrue = 0; 
    public static int pushpush = 0;
     public static int pushpush2 = 0;
GameObject hukidasiText;
    GameObject Childimage;
    GameObject namaeimage;
    GameObject speakmarkimage;
    GameObject speakmarkkimage;
    GameObject hukidasiimage;
   // GameObject Helpimage;
    GameObject Helptext;
    GameObject click;
    //public WebCamController webcam;
 void Start()
    {
        this.hukidasiText = GameObject.Find("ChatterText");
        this.Childimage = GameObject.Find("Speech");
        this.namaeimage = GameObject.Find("nahuda");
         this.speakmarkimage = GameObject.Find("mark");
         this.speakmarkkimage = GameObject.Find("markk");
        this.hukidasiimage = GameObject.Find("hukidasi");
      //  this.Helpimage = GameObject.Find("Help");
        this.Helptext = GameObject.Find("Helptext");
    objGet = GameObject.Find("AICamera(Clone)");
        image = this.GetComponent<Image>();
        Camerascreen.scene = "earth";
          image.sprite = Picturebook;
        
        Canvas = GameObject.Find("Canvas");

     
    }
    public void Click()
    {
        pushpush = 1;
        Debug.Log(Camerascreen.scene);
     
        Debug.Log("最初");

        if (Camerascreen.scene == "earth")
        {
　　　　　　　oya = GameObject.Find("Main Camera");



            if (oya.transform.Find("Book(Clone)") == null)
            {

                GameObject obj = (GameObject)Resources.Load("Book");
                GameObject obj2 = Instantiate(obj, new Vector3(0.0f, 2.5f, 0.0f), Quaternion.identity);
                obj2.transform.parent = oya.transform;
            }
            else
            {
                oya.transform.Find("Book(Clone)").gameObject.SetActive(true);
            }
  　　　　　　Debug.Log("最初２");

               Camerascreen.scene = "Picturebook";
               image.sprite = earth;

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
          
            Canvas.transform.Find("World Population").gameObject.SetActive(false);
            Canvas.transform.Find("2030").gameObject.SetActive(false);
            
             
            this.transform.localScale = new Vector3(1.25f, 1.05f, 1);
             Camerascreen.scene = "Picturebook";
               image.sprite = earth; 
        
        }
        else if (Camerascreen.scene == "Picturebook")
        {
            　　Debug.Log("２回目");
 　　　　　　　　　 image.sprite = Picturebook;
                 Camerascreen.scene = "earth";

            Canvas.transform.Find("World Population").gameObject.SetActive(true);
            Canvas.transform.Find("2030").gameObject.SetActive(true);
       
            objGet = GameObject.Find("Book(Clone)");
            Destroy(objGet);
             objGet = GameObject.Find("Book2(Clone)");
            Destroy(objGet);
          
            this.transform.localScale = new Vector3(1.25f, 1.25f, 1f);
          
        }
        else if (Camerascreen.scene == "Camera")
        {

      Camerascreen.scene = "Picturebook";

            objGet = GameObject.Find("AICamera(Clone)");
            pushpush2 = 1;
            
            Destroy(objGet);
            // GameObject.Find("World Population").SetActive(false);
            // GameObject.Find("2030").SetActive(false);
      
            
            oya = GameObject.Find("Main Camera");



            if (oya.transform.Find("Book(Clone)") == null)
            {

                GameObject obj = (GameObject)Resources.Load("Book");
                GameObject obj2 = Instantiate(obj, new Vector3(0.0f, 2.5f, 0.0f), Quaternion.identity);
                obj2.transform.parent = oya.transform;
            }
            else
            {
                oya.transform.Find("Book(Clone)").gameObject.SetActive(true);
            }
            image.sprite = earth;
            this.transform.localScale = new Vector3(1.25f, 1.05f, 1);
        }
        else if(Camerascreen.scene == "settei")
        {
             Canvas.transform.Find("World Population").gameObject.SetActive(true);
            Canvas.transform.Find("2030").gameObject.SetActive(true);
            Camerascreen.scene = "earth";
            objGet = GameObject.Find("Book(Clone)");
            Destroy(objGet);
            objGet = GameObject.Find("settei(Clone)");
            Destroy(objGet);
            image.sprite = Picturebook;
          this.transform.localScale = new Vector3(1.25f, 1.25f, 1f);
        }
        pushtrue = 0;

    }
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
if(Camerascreen.scene == "Camera")
{
    image.sprite = Picturebook;
}
         Debug.Log(Camerascreen.scene);
        // if (Camerascreen.scene == "earth")
        // {
        //     image.sprite = Picturebook;
        //      this.transform.localScale = new Vector3(1.25f, 1.25f, 1f);
            
           
        // }
        // else if (Camerascreen.scene == "Picturebook")
        // {
        //     image.sprite = earth;
        //     this.transform.localScale = new Vector3(1.25f, 1.05f, 1);
           
        // }
        // else if (Camerascreen.scene == "Camera")
        // {
        //     image.sprite = Picturebook;
        //      this.transform.localScale = new Vector3(1.25f, 1.25f, 1f);
            
        // }
        // else
        // {
        //      image.sprite = earth;
        //      this.transform.localScale = new Vector3(1.25f, 1.05f, 1);
           
        // }
       // Debug.Log(Camerascreen.scene)
    }

    public int pushreturn()
    {
     return pushpush2;
    }

    public void pushreturn2()
    {
     pushpush2=0;
    }

    public void pushreturn3()
    {
     pushpush2=1;
    }
}