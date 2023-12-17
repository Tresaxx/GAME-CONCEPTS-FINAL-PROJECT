using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public bool gameOver = false;
    public bool soundPlayed = false;
    

    public void Setup(int score) {
        if(soundPlayed == false){
            AudioManager.Instance.PlaySFX("Death");
            soundPlayed = true;
        }
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        Time.timeScale = 0;
        gameOver = true;
    }

    public void RestartButton() {
        AudioManager.Instance.PlaySFX("Button");
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        soundPlayed = false;
    }

    public void ExitButton() {
        AudioManager.Instance.PlaySFX("Button");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        soundPlayed = false;
    }
}
