using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sri : MonoBehaviour
{
    Slider hpSlider;
    public static float ninsiki = 1;
    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        hpSlider.value = ninsiki;
    }

    // Update is called once per frame
    void Update()
    {
         ninsiki = hpSlider.value;
         Debug.Log(ninsiki);
    }
}
