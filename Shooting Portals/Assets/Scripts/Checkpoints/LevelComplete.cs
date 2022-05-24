using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] int level; //Stage level



    public void completeLevel()
    {
        PlayerfabLoad.playerLevelSelected = level;
        PlayerfabLoad.updatePlayerCheckpoint("0");
        int playerLevel = PlayerfabLoad.getPlayerLevelAfter();
        if (playerLevel == level) 
        {
            PlayerfabLoad.updatePlayerLevel((level + 1).ToString());
        }
        SceneManager.LoadScene("Loading Screen Portal");
    }

    // private void loadNextScene() {
    //     SceneManager.LoadScene("Loading Screen Portal");
    // }
}