using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public AudioSource deathSound;
    public Text pointsText;
    public bool gameOver = false;
    
    void Awake(){
        deathSound.Play(0);
    }

    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        Time.timeScale = 0;
        gameOver = true;
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void ExitButton() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
