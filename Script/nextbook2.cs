using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextbook2 : MonoBehaviour
{
      GameObject objGet;
    GameObject oya;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextClick()
    {
        objGet = GameObject.Find("Book2(Clone)");
        Destroy(objGet);
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
     
       
}
