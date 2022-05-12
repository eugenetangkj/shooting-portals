using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterIntro : MonoBehaviour
{
    
    void Start()
    {
        int playLevel = PlayerfabLoad.getPlayerLevelAfter();
        if (playLevel == 0)
        {
            PlayerfabLoad.updatePlayerLevel("1");
        }
        Invoke("nextLevel", 89f);
    }

    private void nextLevel() {
        SceneManager.LoadScene("Loading Screen Portal");
    }
}
