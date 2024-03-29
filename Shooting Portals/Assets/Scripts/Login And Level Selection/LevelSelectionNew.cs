using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class handles the logic for the Level Selection scene
public class LevelSelectionNew : MonoBehaviour
{
    #region Level Information Variables
    [SerializeField] GameObject levelChart;
    [SerializeField] GameObject introInformation;
    [SerializeField] GameObject levelOneInformation;
    [SerializeField] GameObject levelTwoInformation;
    [SerializeField] GameObject levelThreeInformation;
    [SerializeField] GameObject levelFourInformation;
    [SerializeField] GameObject levelFiveInformation;
    [SerializeField] GameObject levelSixInformation;
    [SerializeField] GameObject levelSevenInformation;
    [SerializeField] GameObject levelEightInformation;
    [SerializeField] GameObject levelNineInformation;
    [SerializeField] GameObject levelTenInformation;
    [SerializeField] GameObject outroInformation;
    [SerializeField] GameObject[] levelsArray;
    
    [SerializeField] GameObject transition;
    [SerializeField] GameObject acknowledgmentsButton;

    private GameObject currentlySelected;
    #endregion

    void Start()
    {
        Invoke("destroyTransition", 1f);
        for (int i = 0; i <= PlayerfabLoad.getPlayerLevelAfter(); i = i + 1)
        {
            levelsArray[i].SetActive(true);
        }
    }

    #region Select Level Functions
    public void selectIntro()
    {
        PlayerfabLoad.playerLevelSelected = "Intro";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        introInformation.SetActive(true);
        currentlySelected = introInformation;
        
    }

    public void selectLevelOne()
    {
        PlayerfabLoad.playerLevelSelected = "Level 1 Cutscene";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelOneInformation.SetActive(true);
        currentlySelected = levelOneInformation;
    }

    public void selectLevelTwo()
    {
        PlayerfabLoad.playerLevelSelected = "Level 2";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelTwoInformation.SetActive(true);
        currentlySelected = levelTwoInformation;
    }

    public void selectLevelThree()
    {
        PlayerfabLoad.playerLevelSelected = "Level 3 Cutscene";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelThreeInformation.SetActive(true);
        currentlySelected = levelThreeInformation;
    }

    public void selectLevelFour()
    {
        PlayerfabLoad.playerLevelSelected = "Level 4";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelFourInformation.SetActive(true);
        currentlySelected = levelFourInformation;
    }

    public void selectLevelfive()
    {
        PlayerfabLoad.playerLevelSelected = "Level 5 Pre Cutscene";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelFiveInformation.SetActive(true);
        currentlySelected = levelFiveInformation;
    }

    public void selectLevelSix()
    {
        PlayerfabLoad.playerLevelSelected = "Level 6 Cutscene";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelSixInformation.SetActive(true);
        currentlySelected = levelSixInformation;
    }

    public void selectLevelSeven()
    {
        PlayerfabLoad.playerLevelSelected = "Level 7";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelSevenInformation.SetActive(true);
        currentlySelected = levelSevenInformation;
    }

    public void selectLevelEight()
    {
        PlayerfabLoad.playerLevelSelected = "Level 8 Pre Cutscene";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelEightInformation.SetActive(true);
        currentlySelected = levelEightInformation;
    }

    public void selectLevelNine()
    {
        PlayerfabLoad.playerLevelSelected = "Level 9 Cutscene";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelNineInformation.SetActive(true);
        currentlySelected = levelNineInformation;
    }

    public void selectLevelTen()
    {
        PlayerfabLoad.playerLevelSelected = "Level 10 Pre Cutscene";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        levelTenInformation.SetActive(true);
        currentlySelected = levelTenInformation;
    }

    public void selectOutro()
    {
        PlayerfabLoad.playerLevelSelected = "Outro";
        levelChart.SetActive(false);
        acknowledgmentsButton.SetActive(false);
        outroInformation.SetActive(true);
        currentlySelected = outroInformation;
    }
    #endregion

    #region Enter and Back Functions
    
    //Functionality for Enter Button
    public void enterButton()
    {
        if (PlayerfabLoad.playerLevelSelected == "Intro" || PlayerfabLoad.playerLevelSelected == "Outro")
        {
            SceneManager.LoadScene("Loading Screen Portal");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 1 Cutscene" || PlayerfabLoad.playerLevelSelected == "Level 2")
        {
            SceneManager.LoadScene("Loading Screen Industrial");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 3 Cutscene" || PlayerfabLoad.playerLevelSelected == "Level 4" || PlayerfabLoad.playerLevelSelected == "Level 5 Pre Cutscene")
        {
            SceneManager.LoadScene("Loading Screen Forest"); //Supposed to be "Loading Screen Forest"
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 6 Cutscene" || PlayerfabLoad.playerLevelSelected == "Level 7" || PlayerfabLoad.playerLevelSelected == "Level 8 Pre Cutscene")
        {
            SceneManager.LoadScene("Loading Screen Elemental");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 9 Cutscene" || PlayerfabLoad.playerLevelSelected == "Level 10 Pre Cutscene")
        {
            SceneManager.LoadScene("Loading Screen Monster");
        }
    }

    //Functionality for Back Button
    public void backButton()
    {
        currentlySelected.SetActive(false);
        levelChart.SetActive(true);
        acknowledgmentsButton.SetActive(true);
    }
    #endregion

    #region Other Functions
    private void destroyTransition()
    {
        Destroy(transition);
    }
    #endregion
}
