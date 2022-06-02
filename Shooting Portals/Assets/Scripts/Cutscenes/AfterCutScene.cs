using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCutScene : MonoBehaviour
{
    [SerializeField] private int levelToUpdate;
    [SerializeField] private float timelineDuration;
    [SerializeField] private float playerLevelSelected;
    [SerializeField] private string sceneToLoad;



    void Start()
    {
        Invoke("nextLevel", timelineDuration);
    }

    // Update is called once per frame
    void Update()
    {
        //Skips cutscene if player presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextLevel();     
        }   
    }


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
