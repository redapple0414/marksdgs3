using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setteiscene : MonoBehaviour
{
    GameObject earthbutton2;
    GameObject oya;
    GameObject Canvas;
    Image image;
    GameObject objGet;
    public Sprite settei;
    public Sprite kirikae;
      public static int uraomote = 0;
    // Start is called before the first frame update
    void Start()
    {
         Canvas = GameObject.Find("Canvas");
         this.image = this.GetComponent<Image>();
    }

    // Update is called once per frame
   
     public void Click()
    {
        if(Camerascreen.scene == "Camera")
        {
            earthbutton2 = GameObject.Find("SceneButton");
            earthbutton2.GetComponent<SceneButton>().pushreturn3();
            objGet = GameObject.Find("AICamera(Clone)");   
            Destroy(objGet);

            if(setteiscene.uraomote == 1)
            {
                setteiscene.uraomote = 0;
            }
            else
            {
                 setteiscene.uraomote = 1;
            }
            GameObject obj2 = (GameObject)Resources.Load("AICamera");
            GameObject obj3 = Instantiate(obj2, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
            obj3.transform.parent = oya.transform;

        }
        else
        {
            SceneButton.pushpush = 1;
            Camerascreen.scene = "settei";
            Canvas = GameObject.Find("Canvas");
            Canvas.transform.Find("World Population").gameObject.SetActive(false);
            Canvas.transform.Find("2030").gameObject.SetActive(false);
            oya = GameObject.Find("Main Camera");
            objGet = GameObject.Find("Book(Clone)");
            Destroy(objGet);
            objGet = GameObject.Find("AICamera(Clone)");
            Destroy(objGet);
            objGet = GameObject.Find("Book2(Clone)");
            Destroy(objGet);


            if (oya.transform.Find("settei(Clone)") == null)
            {

                GameObject obj3 = (GameObject)Resources.Load("settei");
                GameObject obj4 = Instantiate(obj3, new Vector3(0.0f, 2.5f, 0.0f), Quaternion.identity);
                obj4.transform.parent = oya.transform;
            }
            else
            {
                oya.transform.Find("settei(Clone)").gameObject.SetActive(true);
            }
        }
        
    }
    void Update()
    {
        if (Camerascreen.scene != "settei")
        {
           this.image.enabled = true;
        }
        else
        {
           this.image.enabled = false;
        }
if (Camerascreen.scene == "Camera")
        {
            image.sprite = kirikae;
           
        }
        else
        {
            image.sprite = settei;
           
        }
        
       //Debug.Log(Camerascreen.scene);
    }
}
