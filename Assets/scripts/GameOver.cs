using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;
    public TMP_Text finalScoreText;
    public TMP_Text playerName;

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
                int total = distance + coins;


                HighScoreManager.Instance.AddRun(PlayerSettings.PlayerName, distance, coins);
                Debug.Log($"Saved Run: Distance {distance}, Coins {coins}, Total {distance + coins}");
                if (finalScoreText != null)
                    finalScoreText.text = $"Score: {total}";
                if (playerName != null)
                    playerName.text = $"{PlayerSettings.PlayerName}";
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

    void ShowFinalScore()
    {
        int distance = Score.Instance.GetDistance();
        int coins = Score.Instance.GetCoins();
        int total = distance + coins;

        finalScoreText.text = $"{PlayerSettings.PlayerName} - Score: {total}";
        playerName.text = $"{PlayerSettings.PlayerName}";
    }
}
