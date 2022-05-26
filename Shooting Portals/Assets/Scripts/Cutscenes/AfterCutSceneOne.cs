using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCutSceneOne : MonoBehaviour
{
    
    private void Start()
    {
        int playLevel = PlayerfabLoad.getPlayerLevelAfter();
        if (playLevel == 0)
        {
            PlayerfabLoad.updatePlayerLevel("1");
        }
        Invoke("nextLevel", 89f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int playLevel = PlayerfabLoad.getPlayerLevelAfter();
            if (playLevel == 0)
        {
            PlayerfabLoad.updatePlayerLevel("1");
        }
            nextLevel();
        }
    }

    private void nextLevel() {
        SceneManager.LoadScene("Loading Screen Portal");
    }
}
