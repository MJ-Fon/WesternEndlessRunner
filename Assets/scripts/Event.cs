using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Stats()
    {
        SceneManager.LoadScene("Leaderboard");
    }
    //Settings

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
