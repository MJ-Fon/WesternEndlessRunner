using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RunData 
{
    
    
        public string playerName;
        public int distance;
        public int coins;
        public int totalScore; // distance + coins

    public RunData(string name, int distance, int coins, int totalScore)
    {
        this.playerName = name;
        this.distance = distance;
        this.coins = coins;
        this.totalScore = totalScore;
    }

}
