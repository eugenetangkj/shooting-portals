using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] int level; //Player level to update
    [SerializeField] float selectedLevel; //Player level to select

    //TODO: Update after each level with the corresponding scene to load
    private string[] scenesToLoad = new string[]
        {
            "Loading Screen Industrial",
            "Loading Screen Industrial"
        };



    public void completeLevel()
    {
        PlayerfabLoad.playerLevelSelected = selectedLevel;
        PlayerfabLoad.updatePlayerCheckpoint("0");
        int playerLevel = PlayerfabLoad.getPlayerLevelAfter();
        if (playerLevel == level) 
        {
            PlayerfabLoad.updatePlayerLevel((level + 1).ToString());
        }
        SceneManager.LoadScene(scenesToLoad[level - 1]);
    }

}