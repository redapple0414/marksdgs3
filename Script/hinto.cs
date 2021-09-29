using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class hinto : MonoBehaviour
{
    public Sprite image_object;
    GameObject hintosprite;
    // Start is called before the first frame update
    void Start()
    {
        this.hintosprite = GameObject.Find("hinto");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sethinto()
    {
         this.hintosprite = GameObject.Find("hinto");
         
          this.hintosprite.GetComponent<Image>().sprite = this.image_object;

          hintosprite.transform.DOLocalMove(new Vector3(0, -1000, 0), 0f);
          hintosprite.transform.DOLocalMove(new Vector3(0, -200, 0), 0.5f);
    }
}
