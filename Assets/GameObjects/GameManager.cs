using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    public PauseScene PauseScene;
    public int score;

    public void GameOver(){
        GameOverScreen.Setup(score);
    }

    // Update is called once per frame
    void Update()
    {
        PauseScene.Pause();
        ScoreManager.instance.AddPoint();
    }

}
