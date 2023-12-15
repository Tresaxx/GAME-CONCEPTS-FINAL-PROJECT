using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    public PauseScene PauseScene;
    public int score;
    public float scoreTime;
    private float timer = 0.0f;

    public void Awake(){
        Time.timeScale = 1;
    }

    public void GameOver(){
        GameOverScreen.Setup(score);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(!GameOverScreen.gameOver){
            PauseScene.Pause();
            if(!PauseScene.paused){
                if(timer > scoreTime){
                    ScoreManager.instance.AddPoint(10);
                    timer -= scoreTime;
                }
            }
            score = ScoreManager.instance.score;
        }
    }

}
