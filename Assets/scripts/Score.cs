using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static Score Instance;

    [Header("UI")]
    public TMP_Text DistanceText;
    public TMP_Text CoinText;

    private float distanceScore = 0;
    private int coinScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
/*
        if (DistanceText == null)
            Debug.LogError("DistanceText is not assigned in the Inspector!");

        if (CoinText == null)
            Debug.LogError("CoinText is not assigned in the Inspector!");
        */
    }

    void Update()
    {
        if (Time.timeScale == 0) return;

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            distanceScore += 1 * Time.deltaTime;
            DistanceText.text = ((int)distanceScore).ToString();
        }
    }

    public void AddCoin(int amount)
    {
        coinScore += amount;
        CoinText.text = coinScore.ToString();
    }

    /*
    public TMP_Text ScoreText;
    private float score;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            ScoreText.text = ((int)score).ToString();
        }
    }
    */
}
