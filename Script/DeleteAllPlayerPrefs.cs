using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllPlayerPrefs : MonoBehaviour
{

    public static void Execute()
    {
        
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt ("Clear", 0);
        Debug.Log("PlayerPrefs.DeleteAll()");
    }
}
