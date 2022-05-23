using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCutSceneTwo : MonoBehaviour
{
    
    void Start()
    {
        int playLevel = PlayerfabLoad.getPlayerLevelAfter();
        if (playLevel == 1)
        {
            PlayerfabLoad.updatePlayerLevel("2");
        }
        Invoke("nextLevel", 48.5f);
    }

    private void nextLevel() {
        PlayerfabLoad.playerLevelSelected = -1;
        SceneManager.LoadScene("Loading Scene Industrial");
    }
}

