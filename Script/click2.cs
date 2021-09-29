using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class click2 : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    { 
        this.gameObject.SetActive(false);
        Invoke("Set2", 7.5f);
        this.transform.DOLocalMove(new Vector3(0, 481, 0), 1f).SetDelay(8f).SetLoops(3,LoopType.Restart).SetEase(Ease.Linear);
         Invoke("DelayMethod2", 10f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneButton.pushpush == 1)
        {
         Invoke("DelayMethod2", 0f);
        }
    }
    void DelayMethod2()
{
 
  Destroy(gameObject);
}
void Set2()
{
 this.gameObject.SetActive(true);
 
}
}