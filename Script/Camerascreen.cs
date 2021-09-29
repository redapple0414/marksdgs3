using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
[RequireComponent(typeof(CanvasGroup))]
public class Camerascreen: MonoBehaviour
{
    
     public float DurationSeconds;
    public Ease EaseType;

 　　private CanvasGroup canvasGroup;
    GameObject oya;
    public string markName;
    public static string scene;
    public void Camera()
    {
        GameObject objGet;
        Camerascreen.scene = "Camera";
        oya = GameObject.Find("Main Camera");
        Chatterscript.selectmarkname = markName;
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
        this.canvasGroup = this.GetComponent<CanvasGroup>();
    　this.canvasGroup.DOFade(0.0f, this.DurationSeconds).SetEase(this.EaseType).SetLoops(-1, LoopType.Yoyo);
     Invoke("MAX", 5);
    }
    

    void Update()
    {
     Debug.Log(Chatterscript.selectmarkname);
    }
    
    private void MAX()
    {
      canvasGroup.DOFade(1.0f,1);
    }
	
}
