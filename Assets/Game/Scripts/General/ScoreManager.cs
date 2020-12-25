using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText;
    public Text hightScoreText;
    public int score;
    public int highScore = 0;

    private void Awake() {
        Instance = this;
    }
    public void UpdateScore(int score){
        this.score += score;
        GetHighScore(this.score);
        scoreText.text = "Score - "+ this.score.ToString();
    }

    void GetHighScore(int currentScore)
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
            hightScoreText.text ="HighScore - "+ highScore.ToString();
        }
    }
}
