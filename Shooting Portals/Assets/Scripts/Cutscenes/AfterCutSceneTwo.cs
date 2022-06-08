using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCutSceneTwo : MonoBehaviour
{
    
    void Start()
    {
        Invoke("nextLevel", 48.5f);
    }

     private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextLevel();
        }
    }

    private void nextLevel() {
        PlayerfabLoad.playerLevelSelected = "Level 1";
        SceneManager.LoadScene("Loading Screen Industrial");
    }
}

