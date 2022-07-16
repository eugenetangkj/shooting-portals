using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class is responsible for the logic update after the playing of a cutscene
public class AfterCutScene : MonoBehaviour
{
    #region AfterCutScene Data
    [SerializeField] private int levelToUpdate; //Level to update for player after cutscene
    [SerializeField] private float timelineDuration; //Duration of the timeline
    [SerializeField] private string playerLevelSelected; //Desired level after the cutscene
    [SerializeField] private string sceneToLoad; //Loading screen to transition into, after the cutscene

    #endregion

    private void Start()
    {
        Invoke("nextLevel", timelineDuration);
    }


    private void Update()
    {
        //Skips cutscene if player presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextLevel();     
        }   
    }


    //Handles the logic after the playing of a cutscene. It updates the player's level if necessary, and loads into the corresponding loading screen
    private void nextLevel()
    {
        //Updates the player's level stored on Playfab
        if (PlayerfabLoad.getPlayerLevelAfter() < levelToUpdate)
        {
            PlayerfabLoad.updatePlayerLevel(levelToUpdate.ToString());
        }
        //Updates the player's level selected
        PlayerfabLoad.playerLevelSelected = playerLevelSelected;
        SceneManager.LoadScene(sceneToLoad);

    }
}
