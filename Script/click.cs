using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class click : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    { 
        this.gameObject.SetActive(false);
        Invoke("Set", 5f);
        this.transform.DOLocalMove(new Vector3(169, -121, 0), 1f).SetDelay(6f).SetLoops(3,LoopType.Restart).SetEase(Ease.Linear);
         Invoke("DelayMethod", 7.75f);
        
    }

    // Update is called once per frame
    void Update()
    {
    if(SceneButton.pushpush == 1)
        {
         Invoke("DelayMethod", 0f);
        }    
    }
    void DelayMethod()
{
  Destroy(gameObject);
}
void Set()
{
 this.gameObject.SetActive(true);
}
}
