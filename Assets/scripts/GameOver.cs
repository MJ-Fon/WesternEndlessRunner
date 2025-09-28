using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            GameOverPanel.SetActive(true);

            if (!saved)
            {
                int distance = Score.Instance.GetDistance();
                int coins = Score.Instance.GetCoins();

                HighScoreManager.Instance.AddRun("Alex", distance, coins);
                Debug.Log($"Saved Run: Distance {distance}, Coins {coins}, Total {distance + coins}");
                saved = true;
            }
        }
        
    }
    private bool saved = false;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
