using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementDisplay : MonoBehaviour
{
    public GameObject lockImage;
    public GameObject lockIcon;
    public int achievementNum;
    // Update is called once per frame
    void Update()
    {
        if(AchievementManager.achievements[achievementNum].achieved == true){
            lockImage.SetActive(false);
            lockIcon.SetActive(false);
        }
    }
}
