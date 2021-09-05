using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class MainMenu : MonoBehaviour
{

    public Button LoadButton;
    //public TextMeshPro loadButtonTextMeshPro;
    void Start()
    {
        Application.targetFrameRate = 60;
        string loadpath = Application.persistentDataPath + "/QuickSave/Player.json";
        if (!System.IO.File.Exists(loadpath))
        {
            //loadButtonTextMeshPro.faceColor = new Color32(255, 255, 255, 0);
            LoadButton.interactable = false;
            
        }
        
    }

    public void PlayGame ()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        PlayerPrefs.SetString("Load", "load");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }


}
