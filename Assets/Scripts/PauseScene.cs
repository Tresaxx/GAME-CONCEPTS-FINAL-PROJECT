using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    public bool paused = false;


    public void Pause(){
        if(Input.GetKeyDown(KeyCode.Escape) && paused == false){
            gameObject.SetActive(true);
            paused = true;
            Debug.Log("PAuse");
            Time.timeScale = 0;
        } else if(Input.GetKeyDown(KeyCode.Space) && paused == true){
            gameObject.SetActive(false);
            paused = false;
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    public void ExitButton() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
