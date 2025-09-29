using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    public List<RunData> runs = new List<RunData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // survives scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddRun(string playerName, int distance, int coins)
    {
        RunData newRun = new RunData(
            playerName,
            distance,
            coins,
            distance + coins
        );

        runs.Add(newRun);

        runs = runs.OrderByDescending(r => r.totalScore).ToList();
        if (runs.Count > 10)
            runs = runs.Take(10).ToList();
    }
    /*
    public void AddRun(string playerName, int distance, int coins)
    {
        RunData newRun = new RunData
        {
            playerName = playerName,
            distance = distance,
            coins = coins,
            totalScore = distance + coins
        };

        runs.Add(newRun);

        runs = runs.OrderByDescending(r => r.totalScore).ToList();
        if (runs.Count > 10)
            runs = runs.Take(10).ToList();
    }
    */
}
