using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class earth : MonoBehaviour,IDragHandler
{
public static int katikati = 0;
    private AudioSource audioSource2;
    public AudioClip GetAudio2;
   
    void Start()
    {

        audioSource2 = gameObject.GetComponent<AudioSource>();
        audioSource2.clip = GetAudio2;
     
    }


    void Update()
    {

    }
    public void Kaiten()
    {




    }

    public void OnDrag(PointerEventData eventData)
    {
    //this.GetComponent<Chatterscript>().Sethukidasi();
        audioSource2.Play ();
        earth.katikati = 1;
        if (eventData.position.y <= Screen.height / 2)
        {
             audioSource2.Play ();
            if (eventData.delta.x > 0)
            {
          
                this.transform.Rotate(0, 0, 3);
            }
            else if (eventData.delta.x < 0)
            {
       
                this.transform.Rotate(0, 0, -3);
            }
            audioSource2.Play ();
        }
        else
        {
             audioSource2.Play ();
            if (eventData.delta.x > 0)
            {
            
                this.transform.Rotate(0, 0, -3);
            }
            else if (eventData.delta.x < 0)
            {
          
                this.transform.Rotate(0, 0, 3);
            }   
            audioSource2.Play ();
        }

    }
    public void OnScroll()
    {
        earth.katikati = 1;
//this.GetComponent<Chatterscript>().Sethukidasi();
        audioSource2.Play ();
       float rotatez = Input.GetAxis("Mouse ScrollWheel");
       this.transform.Rotate(0,0,rotatez*20);
    }
    
  }

