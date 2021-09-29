using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementCheck : MonoBehaviour
{
    GameObject Choose;
    public GameObject hanabi;
    Chatterscript[] Chatterscripts; 
    public static bool ClearOK;

   GameObject earthkesu;
   GameObject hukidashikesu;
    
    void Start()
    {
        Chatterscripts = GetComponentsInChildren<Chatterscript>();
        Choose = GameObject.Find("Choose");
        
        earthkesu = GameObject.Find("Speech");
        hukidashikesu = GameObject.Find("hukidasi");
        
           earthkesu.SetActive(true);
           hukidashikesu.SetActive(true);

        CheckAchievement();

    }
    bool CheckAchievement()
    {
        
  
        for (int i = 0; i < Chatterscripts.Length; i++)
        {
           
            if (Chatterscripts[i].Achievement != 1)
            {
                PlayerPrefs.SetInt ("Clear", 0);
             
                return false;

            }
        }


          PlayerPrefs.SetInt ("Clear", 1);
          return true;
    }


    void Update()
    {
       CheckAchievement();
       

        if(PlayerPrefs.GetInt ("Clear") == 1)
        {

            hanabi.SetActive(true);
            this.transform.Rotate(0, 0, -0.5f);
             Choose.SetActive(false);
              AchievementCheck.ClearOK = true;

              earthkesu.SetActive(false);
              hukidashikesu.SetActive(false);
              
        }
        else
        {

             Choose.SetActive(true);
             hanabi.SetActive(false);
              AchievementCheck.ClearOK = false;

           
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Achievement = 1");
            for (int i = 0; i < Chatterscripts.Length; i++)
            {
                PlayerPrefs.SetInt ("Clear", 1);
               PlayerPrefs.SetInt(Chatterscripts[i].markName,1);
            }
        }

    }
}
