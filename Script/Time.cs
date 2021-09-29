using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう
public class Time : MonoBehaviour
{
    public Text time;


    // Start is called before the first frame update
    void Start()
    {
        string markName = GetComponentInParent<Explanation>().markName;
        GetComponent<Text>().text = PlayerPrefs.GetString(markName + "Date");
        Debug.Log(PlayerPrefs.HasKey(GetComponentInParent<Explanation>().markName + "Date"));
    }


    // Update is called once per frame

}
