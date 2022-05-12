using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    private int currLevel = 11;
    private int levelSelected = 0;

    private static int[,] levelRGBA = new int[,]
    {
        {12, 37, 53, 1}, //intro
        {24, 24, 24, 1},
        {24, 24, 24, 1},
        {12, 68, 39, 1},
        {12, 68, 39, 1},
        {72, 11, 48, 1},
        {72, 11, 48, 1},
        {72, 11, 48, 1},
        {50, 16, 78, 1},
        {50, 16, 78, 1},
        {50, 16, 78, 1},
        {12, 37, 53, 1} //ending
    };
    
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject unlockable;

    private Renderer backgroundRenderer;
    private TextMeshProUGUI levelDisplay;

    private Animator unlockableAnimator;


    private void Start()
    {
        //currLevel = PlayerfabLoad.getPlayerLevelAfter();
        backgroundRenderer = background.GetComponent<Renderer>();
        levelDisplay = level.GetComponent<TextMeshProUGUI>();
        unlockableAnimator = unlockable.GetComponent<Animator>();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            decreaseLevel();
        } else if (Input.GetKeyDown(KeyCode.P))
        {
            increaseLevel();
        }
    }

    private void decreaseLevel()
    {
        if (levelSelected == 0)
        {
            //do nothing
        } else {
            levelSelected = levelSelected - 1;
            changeBackgroundColor(levelSelected);
            changeLevelDisplay(levelSelected);

        }
    }

    private void increaseLevel()
    {
        if (levelSelected == 11 )
        {
            //do nothing
        } else if (levelSelected == currLevel) {
            unlockableAnimator.Play("appear");
            Debug.Log("have not unlocked");
        } else {
            levelSelected = levelSelected + 1;
            changeBackgroundColor(levelSelected);
            changeLevelDisplay(levelSelected);
        }
    }

    private void changeBackgroundColor(int levelSelected)
    {
        Color newColor = new Color(levelRGBA[levelSelected, 0] / 255, levelRGBA[levelSelected, 1] / 255,
                                   levelRGBA[levelSelected, 2] / 255, levelRGBA[levelSelected, 3] / 255);
        backgroundRenderer.material.color = newColor;
    }

    private void changeLevelDisplay(int levelSelected)
    {
        if (levelSelected == 0)
        {
            levelDisplay.text = "Intro";
        } else if (levelSelected == 11)
        {
            levelDisplay.text = "Ending";
        } else {
            levelDisplay.text = "Level" + levelSelected;
        }
    }
}
