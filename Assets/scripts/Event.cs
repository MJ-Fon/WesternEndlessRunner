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

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
