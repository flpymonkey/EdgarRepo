using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceEngine : MonoBehaviour
{
    private int levelUpExperienceReq = 100;

    public void IncreaseSkillExperience(string skillName, int experienceGained)
    {
        int currentExperience = 0;
        if (PlayerPrefs.HasKey(skillName))
        {
            currentExperience = PlayerPrefs.GetInt(skillName);
        } 
        
        if (currentExperience + experienceGained >= levelUpExperienceReq)
        {
            LevelUp(skillName);
        }
        int newCurrentExperience = (currentExperience + experienceGained) % levelUpExperienceReq;
        PlayerPrefs.SetInt(skillName, newCurrentExperience);
        print("Gained " + experienceGained + " towards visual calculus");
        print(skillName + " now has " + newCurrentExperience + " xp");
    }

    private void LevelUp(string skillName)
    {
        int currentLevel = 0;
        if (PlayerPrefs.HasKey(skillName+"Level"))
        {
            currentLevel = PlayerPrefs.GetInt(skillName + "Level");
        }
        PlayerPrefs.SetInt(skillName + "Level", currentLevel + 1);
        print(skillName + " has leveled up to level " + PlayerPrefs.GetInt(skillName + "Level"));
    }

    public int GetSkillCurrentLevel(string skillName)
    {
        return PlayerPrefs.GetInt(skillName);
    }
}
