using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    public PauseScene PauseScene;
    public PowerUp powerUp;
    public Player player;
    public int score;

    public void Awake(){
        Time.timeScale = 1;
    }

    public void GameOver(){
        GameOverScreen.Setup(score);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameOverScreen.gameOver){
            PauseScene.Pause();
            if(!PauseScene.paused){
                ScoreManager.instance.AddPoint(1);
            }
            score = ScoreManager.instance.score;
        }
    }

    public void PowerUp(){
        player.speed *= 2;
    }

}
