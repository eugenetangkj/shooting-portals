using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class is responsible for the logic update after the player completes a level.
public class LevelComplete : MonoBehaviour
{
    #region Level Complete Data
    [SerializeField] private Player player;
    [SerializeField] int level; //Player level to update
    [SerializeField] string selectedLevel; //Player level to select

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
    #endregion
    

    //Sets the player's checkpoint back to 0, increase player's level by 1 if player completes the level for the first time, 
    //and loads the next corresponding scene
    public void completeLevel()
    {
        PlayerfabLoad.playerLevelSelected = selectedLevel;
        PlayerfabLoad.updatePlayerCheckpoint("0"); //Checkpoint update
        int playerLevel = PlayerfabLoad.getPlayerLevelAfter();
        if (playerLevel == level) 
        {
            PlayerfabLoad.updatePlayerLevel((level + 1).ToString()); //Level update
        }
        SceneManager.LoadScene(scenesToLoad[level - 1]); //Load scene
    }

}