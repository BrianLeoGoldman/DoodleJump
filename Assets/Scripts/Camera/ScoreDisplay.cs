using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    CoinManager manager;
    public int score;
    public int coins;
    int maxScore;
    int maxCoins;
    private GUIStyle guiStyle = new GUIStyle();
    public static ScoreDisplay display;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<CoinManager>();
        score = 0;
        coins = 0;
        display = this;
        maxScore = PlayerPrefs.GetInt("MaxScore1", 0);
        maxCoins = PlayerPrefs.GetInt("MaxCoins1", 0);
    }

    void OnGUI()
    {
        guiStyle.fontSize = 35;
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score, guiStyle);
        GUI.Label(new Rect(10, 70, 100, 20), "Max Score: " + maxScore, guiStyle);
        GUI.Label(new Rect(600, 10, 100, 20), "Coins: " + coins, guiStyle);
        GUI.Label(new Rect(600, 70, 100, 20), "Max Coins: " + maxCoins, guiStyle);

    }

    void Update()
    {
        score = (int)transform.position.y;  //Sets the actual score based on the players height
        coins = (int)manager.coins;  //Sets the number of coins collected (based on the GameManager)

    }

    public void CheckMaxScoreAndCoins()
    {
        if (score > maxScore)  //If there is a new maxScore
        {
            Debug.Log("Saving score...");
            PlayerPrefs.SetInt("MaxScore1", score);  //Saves the new maxScore
        }
        if (coins > maxCoins)  //If there is a new maxCoins
        {
            Debug.Log("Saving coins...");
            PlayerPrefs.SetInt("MaxCoins1", coins);  //Saves the new maxCoins
        }
    }

}
