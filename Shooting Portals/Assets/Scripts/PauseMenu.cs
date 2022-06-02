using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject controlUI;
    public GameObject restartUI;
    public GameObject quitUI;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                //Game is already paused. Pressing escape will
                //resume the game
                Resume();
            } else
            {
                //Game is not paused. Pressing escape will
                //pause the game
                Pause();
            }
        }
    }

    #region Resume and Pause Functions
    public void Resume()
    {
        //Disables all active menus
        pauseMenuUI.SetActive(false);
        controlUI.SetActive(false);
        restartUI.SetActive(false);
        quitUI.SetActive(false);
        Time.timeScale = 1f; //Resumes the game as per normal
        isGamePaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true); //Enables the pause menu
        Time.timeScale = 0f; //Freezes the game
        isGamePaused = true;
    }
    #endregion

    #region Restart Level Functions
    public void Restart()
    {
        restartUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void YesForRestart()
    {
        PlayerfabLoad.updatePlayerCheckpoint("0"); //Resets checkpoint to 0
        Time.timeScale = 1f; //Resumes time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Restarts current level scene
    }

    public void NoForRestart()
    {
        restartUI.SetActive(false);
        pauseMenuUI.SetActive(true); 
    }

    #endregion

    #region Controls Functions
    public void Controls()
    {
        controlUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void BackForControl()
    {
        controlUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    #endregion

    #region Quit Level Functions
    public void QuitLevel()
    {
        quitUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void YesForQuit()
    {
        PlayerfabLoad.updatePlayerCheckpoint("0"); //Resets checkpoint to 0
        Time.timeScale = 1f; //Resumes time
        SceneManager.LoadScene("Level Selection");
    }

    public void NoForQuit()
    {
        quitUI.SetActive(false);
        pauseMenuUI.SetActive(true); 
    }

    #endregion

    
}
