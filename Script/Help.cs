using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Help : MonoBehaviour
{
    public int Achievement;
    public string markName;
    public Sprite Child;
    public Sprite Child2;
    public Sprite nullimage;
    Image ChildImage;

    // Start is called before the first frame update
    void Start()
    {
        ChildImage = gameObject.GetComponent<Image>();
        Achievement = PlayerPrefs.GetInt(markName);
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.Achievement == -1)
        {
            ChildImage.sprite = Child2;
        }
        else if (this.Achievement > 0)
        {
            ChildImage.sprite = Child;
        }
        else
        {
            ChildImage.sprite = nullimage;
        }

    }
}
