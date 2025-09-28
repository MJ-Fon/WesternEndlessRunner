using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    public Transform container;
    public GameObject rowPrefab; // must have TMP_Text on it

    void Start()
    {
        DisplayScores();
    }

    void DisplayScores()
    {
        Debug.Log("Runs count: " + HighScoreManager.Instance.runs.Count);
        foreach (Transform child in container)
            Destroy(child.gameObject);

        int rank = 1;
        foreach (var run in HighScoreManager.Instance.runs)
        {
            GameObject row = Instantiate(rowPrefab, container);
            TMP_Text text = row.GetComponent<TMP_Text>();
            text.text = $"{rank}.| {run.playerName} – | – {run.distance} – | – {run.coins} – | – {run.totalScore}";
            rank++;
        }
    }
}
