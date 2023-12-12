using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public Text powerUpTimeText;

    public int score = 0;
    public int highscore = 0;
    public float powerUpTime = 0;

    private void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    public void AddPoint(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString() + " POINTS";
        if(highscore < score){      
        PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void PowerUpTime(float addPowerUpTime){
        powerUpTime = addPowerUpTime;
        if(addPowerUpTime <= 0){
            powerUpTime = 0;
        }
        powerUpTimeText.text = "POWERUP TIME: " + powerUpTime.ToString("F2");
    }
}
