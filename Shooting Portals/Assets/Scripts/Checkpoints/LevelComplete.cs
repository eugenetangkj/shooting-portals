using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] int level; //Player level to update
    [SerializeField] string selectedLevel; //Player level to select

    //TODO: Update after each level with the corresponding scene to load
    private string[] scenesToLoad = new string[]
        {
            "Loading Screen Industrial",
            "Loading Screen Industrial",
            "Loading Screen Forest",
            "Loading Screen Forest",
            "Loading Screen Forest",
            "Loading Screen Elemental",
            "Loading Screen Elemental",
            "Loading Screen Elemental",
            "Loading Screen Monster",
            "Loading Screen Monster"
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