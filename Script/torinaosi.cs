using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class torinaosi: MonoBehaviour
{
    
    GameObject oya;
  string mark;
    public static string scene;
    public void Loadcamera(string markName)
    {
      this.mark = markName;
    }
    public void torinaosiCamera()
    {
        GameObject objGet;
        Camerascreen.scene = "Camera";
        oya = GameObject.Find("Main Camera");
        Chatterscript.selectmarkname = this.mark;
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
    // Start is called before the first frame update
    void Start()
    {
      
    }
    
    // Update is called once per frame
    void Update()
    {
     
    }
  
	
}
