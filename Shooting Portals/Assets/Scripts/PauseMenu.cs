using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class encapsulates the Pause Menu used in the levels.
public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject controlUI;
    public GameObject restartUI;
    public GameObject quitUI;
    public float levelToSelect;
    
    [SerializeField] private GameObject[] tutorialPrompts;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                //Game is already paused. Pressing p will resume the game
                Resume();
            } else
            {
                //Game is not paused. Pressing p will pause the game
                Pause();
            }
        }
    }

    #region Resume and Pause Functions

    //Resumes the game
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

    //Pauses the game
    private void Pause()
    {
        if (tutorialPrompts[0] != null)
        {
        foreach (GameObject tutorial in tutorialPrompts)
        {
            tutorial.GetComponent<Animator>().SetBool("appear", false);
            tutorial.SetActive(false);
        }
        }
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
        isGamePaused = false;
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
        PlayerfabLoad.playerLevelSelected = "Level Selection";
        Time.timeScale = 1f; //Resumes time
        SceneManager.LoadScene("Level Selection");
        isGamePaused = false;
    }

    public void NoForQuit()
    {
        quitUI.SetActive(false);
        pauseMenuUI.SetActive(true); 
    }

    #endregion

    
}
