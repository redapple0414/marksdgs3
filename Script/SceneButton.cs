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

    //public WebCamController webcam;

    public void Click()
    {
        pushpush = 1;
        Debug.Log(Camerascreen.scene);
        if (Camerascreen.scene == "earth")
        {
            Camerascreen.scene = "Picturebook";
            Canvas.transform.Find("World Population").gameObject.SetActive(false);
            Canvas.transform.Find("2030").gameObject.SetActive(false);
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
        }
        else if (Camerascreen.scene == "Picturebook")
        {
            Canvas.transform.Find("World Population").gameObject.SetActive(true);
            Canvas.transform.Find("2030").gameObject.SetActive(true);
            Camerascreen.scene = "earth";
            objGet = GameObject.Find("Book(Clone)");
            Destroy(objGet);
             objGet = GameObject.Find("Book2(Clone)");
            Destroy(objGet);
          
        }
        else if (Camerascreen.scene == "Camera")
        {
            objGet = GameObject.Find("AICamera(Clone)");
            pushpush2 = 1;
            
            Destroy(objGet);
            Canvas.transform.Find("World Population").gameObject.SetActive(false);
            Canvas.transform.Find("2030").gameObject.SetActive(false);
            Camerascreen.scene = "Picturebook";
            
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
        }
        pushtrue = 0;

    }
    // Start is called before the first frame update
    void Start()
    {
        objGet = GameObject.Find("AICamera(Clone)");
        image = this.GetComponent<Image>();
        Camerascreen.scene = "earth";
        
        Canvas = GameObject.Find("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        if (Camerascreen.scene == "earth")
        {
            image.sprite = Picturebook;
             this.transform.localScale = new Vector3(1.25f, 1.25f, 1f);
            
             this.transform.localPosition = new Vector3(900,-460,0);
        }
        else if (Camerascreen.scene == "Picturebook")
        {
            image.sprite = earth;
            this.transform.localScale = new Vector3(1.25f, 1.05f, 1);
               this.transform.localPosition = new Vector3(900,-470,0);
        }
        else if (Camerascreen.scene == "Camera")
        {
            image.sprite = Picturebook;
             this.transform.localScale = new Vector3(1.25f, 1.25f, 1f);
             this.transform.localPosition = new Vector3(900,-470,0);
        }
        else
        {
             image.sprite = earth;
             this.transform.localScale = new Vector3(1.25f, 1.05f, 1);
             this.transform.localPosition = new Vector3(900,-460,0);
        }
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