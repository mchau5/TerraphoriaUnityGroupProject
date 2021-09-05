using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CI.QuickSave;
using System.IO;

// Resource used: https://www.youtube.com/watch?v=JivuXdrIHK0

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public Player player;
    public GameObject mPauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        mPauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    void Pause()
    {
        mPauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SaveGame()
    {
        if (!player.S)
        {
            player.SE = 1;
        }

        if (!player.S1)
        {
            player.SE1 = 1;
        }

        if (!player.S2)
        {
            player.SE2 = 1;
        }

        if (!player.S3)
        {
            player.SE3 = 1;
        }

        if (!player.S4)
        {
            player.SE4 = 1;
        }

        if (!player.BrokenOb)
        {
            player.DM = 1;
        }

        var writer = QuickSaveWriter.Create("Player");
        writer.Write("currentPos", player.MainPlayer.position);
        writer.Write("currentRot", player.MainPlayer.rotation);
        writer.Write("SE", player.SE);
        writer.Write("SE1", player.SE1);
        writer.Write("SE2", player.SE2);
        writer.Write("SE3", player.SE3);
        writer.Write("SE4", player.SE4);
        writer.Write("DM", player.DM);
        writer.Write("Score", player.scoreManager.myCurrentCollected());
        writer.Commit();

        Debug.Log("Save Detected");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
