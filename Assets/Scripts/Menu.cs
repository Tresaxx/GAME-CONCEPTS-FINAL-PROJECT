using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Start(){
        AudioManager.Instance.PlayMusic("Menu");
    }
    public void StartButton() {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void ButtonNoise(){
        AudioManager.Instance.PlaySFX("Button");
    }
}
