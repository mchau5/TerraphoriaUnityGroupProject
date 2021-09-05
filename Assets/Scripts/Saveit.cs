using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public class Saveit : MonoBehaviour
{
    

    public void Save()
    {
        
        Debug.Log("Save Detected");
    }
    public void Load()
    {
        string mySavedScene = PlayerPrefs.GetString("sceneName");
        Application.LoadLevel(mySavedScene);
        Debug.Log("Load Detected");
    }
}
