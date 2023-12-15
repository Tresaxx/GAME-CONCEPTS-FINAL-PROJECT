using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static List<Achievement> achievements;

    public Player player;
    public PuzzleManager puzzle;

    public bool AchievementUnlocked(string achievementName)
    {
        bool result = false;

        if (achievements == null)
            return false;

        Achievement[] achievementsArray = achievements.ToArray();
        Achievement a = Array.Find(achievementsArray, ach => achievementName == ach.title);

        if (a == null)
            return false;

        result = a.achieved;

        return result;
    }

    private void Start()
    {
        InitializeAchievements();
    }

    private void InitializeAchievements()
    {
        if (achievements != null)
            return;

        achievements = new List<Achievement>();
        achievements.Add(new Achievement("So Much Power", "Get 10 power ups.", (object o) => player.powerUpsGot >= 10));
        achievements.Add(new Achievement("All The Power", "Get 25 power ups.", (object o) => player.powerUpsGot >= 25));
        achievements.Add(new Achievement("Puzzles!", "Complete a puzzle.", (object o) => puzzle.puzzlesCompleted >= 5));
        achievements.Add(new Achievement("Speedy Time", "Stay in powerup time for 30 seconds.", (object o) => player.powerTime >= 30));
        achievements.Add(new Achievement("So Fast", "Stay in powerup time for 60 seconds.", (object o) => player.powerTime >= 60));
        achievements.Add(new Achievement("THE FLASH", "Stay in powerup time for 180 seconds.", (object o) => player.powerTime >= 180));
        achievements.Add(new Achievement("Newbie", "Get a score of 10,000.", (object o) => ScoreManager.instance.highscore >= 10000));
        achievements.Add(new Achievement("Getting There", "Get a score of 50,000.", (object o) => ScoreManager.instance.highscore >= 50000));
        achievements.Add(new Achievement("PRO!", "Get a score of 100,000.", (object o) => ScoreManager.instance.highscore >= 100000));
        achievements.Add(new Achievement("UNREAL!", "Get a score of 500,000.", (object o) => ScoreManager.instance.highscore >= 500000));
        achievements.Add(new Achievement("GODLIKE!", "Get a score of 1,000,000.", (object o) => ScoreManager.instance.highscore >= 1000000));
        achievements.Add(new Achievement("bruh", "Get a score of 5,000,000.", (object o) => ScoreManager.instance.highscore >= 5000000));
    }

    private void Update()
    {
        CheckAchievementCompletion();
    }

    private void CheckAchievementCompletion()
    {
        if (achievements == null)
            return;

        foreach (var achievement in achievements)
        {
            achievement.UpdateCompletion();
        }
    }
}

public class Achievement
{
    public Achievement(string title, string description, Predicate<object> requirement)
    {
        this.title = title;
        this.description = description;
        this.requirement = requirement;
    }

    public string title;
    public string description;
    public Predicate<object> requirement;

    public bool achieved;

    public void UpdateCompletion()
    {
        if (achieved)
            return;

        if (RequirementsMet())
        {
            Debug.Log($"{title}: {description}");
            achieved = true;
        }
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}