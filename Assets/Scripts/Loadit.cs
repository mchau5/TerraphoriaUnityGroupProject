using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadit : MonoBehaviour
{

    public Saveit savedata;

    // Use this for initialization
    void Start()
    {
    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 200, 200), "Play"))
        {
            // Application.LoadLevel("JSONScene");
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(0, 200, 500, 200), "Load"))   //�⼸����ťֻ�ǲ���,һ��������,����Ҫ����ɾ��,�����Լ�����
        {
            // Application.LoadLevel("JSONScene");
            savedata.Load();
        }
        
    }
}