// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using UnityEngine.SceneManagement;

// public class LevelSelection : MonoBehaviour
// {
//     private int currLevel;
//     private string levelSelected = PlayerfabLoad.playerLevelSelected;

//     [SerializeField] GameObject player;

//     private static float[,] levelRGBA = new float[,]
//     {
//         {12f, 37f, 53f, 1f}, //intro
//         {24f, 24f, 24f, 1f},
//         {24f, 24f, 24f, 1f},
//         {12f, 68f, 39f, 1f},
//         {12f, 68f, 39f, 1f},
//         {72f, 11f, 48f, 1f},
//         {72f, 11f, 48f, 1f},
//         {72f, 11f, 48f, 1f},
//         {50f, 16f, 78f, 1f},
//         {50f, 16f, 78f, 1f},
//         {50f, 16f, 78f, 1f},
//         {12f, 37f, 53f, 1f} //ending
//     };
    
//     [SerializeField] private GameObject cameraObject;
//     [SerializeField] private GameObject background;
//     [SerializeField] private GameObject level;
//     [SerializeField] private GameObject unlockable;

//     [SerializeField] private GameObject transition;

//     private Camera cameraComponent;
//     private SpriteRenderer backgroundSpriteRenderer;
//     private TextMeshProUGUI levelDisplay;

//     private Animator unlockableAnimator;


//     private void Start()
//     {
        
//         currLevel = PlayerfabLoad.getPlayerLevelAfter();
//         cameraComponent = cameraObject.GetComponent<Camera>();
//         backgroundSpriteRenderer = background.GetComponent<SpriteRenderer>();
//         levelDisplay = level.GetComponent<TextMeshProUGUI>();
//         unlockableAnimator = unlockable.GetComponent<Animator>();

//         changeBackgroundColor((int) levelSelected);
//         changeLevelDisplay((int) levelSelected);
        
//     }

    
//     private void Update()
//     {
//         unlockableAnimator.SetInteger("set", 0);

//         if (Input.GetKeyDown(KeyCode.O) && PortalContactSelection.checkContact())
//         {
//             decreaseLevel();
//         } else if (Input.GetKeyDown(KeyCode.P) && PortalContactSelection.checkContact())
//         {
//             increaseLevel();
//         } else if (Input.GetKeyDown(KeyCode.UpArrow) && PortalContactSelection.checkContact())
//         {
//             transition.GetComponent<Animator>().SetTrigger("play");
//             player.GetComponent<Animator>().SetTrigger("disappear");
//             Invoke("nextLevel", 4f);
//         }
//     }

//     private void decreaseLevel()
//     {
//         if (levelSelected == 0)
//         {
//             //do nothing
//         } else {
//             levelSelected = levelSelected - 1;
//             changeBackgroundColor((int) levelSelected);
//             changeLevelDisplay((int) levelSelected);

//         }
//     }

//     private void increaseLevel()
//     {
//         if (levelSelected == 11 )
//         {
//             //do nothing
//         } else if (levelSelected == currLevel) {
//             unlockableAnimator.SetInteger("set", 1);
//         } else {
//             levelSelected = levelSelected + 1;
//             changeBackgroundColor((int) levelSelected);
//             changeLevelDisplay((int) levelSelected);
//         }
//     }

//     private void changeBackgroundColor(int levelSelected)
//     {
//         //Debug.Log("reached change color");
//         Color newColor = new Color(levelRGBA[levelSelected, 0] / 255f, levelRGBA[levelSelected, 1] / 255f,
//                                    levelRGBA[levelSelected, 2] / 255f, levelRGBA[levelSelected, 3] / 255f);
//         Debug.Log(levelRGBA[levelSelected, 0] / 255);
//         cameraComponent.backgroundColor = newColor;
//         backgroundSpriteRenderer.color = newColor;
        
//     }

//     private void changeLevelDisplay(int levelSelected)
//     {
//         if (levelSelected == 0)
//         {
//             levelDisplay.text = "Intro";
//         } else if (levelSelected == 11)
//         {
//             levelDisplay.text = "Ending";
//         } else {
//             levelDisplay.text = "Level " + levelSelected;
//         }
//     }

//     //To be amended accordingly again
//     private void nextLevel()
//     {
//         if (levelSelected == 0)
//         {
//             PlayerfabLoad.playerLevelSelected = 0.1f;
//             SceneManager.LoadScene("Intro Cut Scene");
//         } else if (levelSelected == 1)
//         {
//             PlayerfabLoad.playerLevelSelected = 1.1f;
//             SceneManager.LoadScene("Loading Screen Industrial");
//         } else if (levelSelected == 2)
//         {
//             PlayerfabLoad.playerLevelSelected = 2.1f;
//             SceneManager.LoadScene("Loading Screen Industrial");
//         } else if (levelSelected == 3)
//         {
//             SceneManager.LoadScene("Level Selection");
//         }
//     }
// }
