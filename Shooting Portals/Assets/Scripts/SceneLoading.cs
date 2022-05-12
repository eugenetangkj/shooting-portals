using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    private int playerCurrLevel;
    [SerializeField] Image progressBar;

    
    private void Start()
    {
        //Gets player's current level to decide which scene to transition into
        playerCurrLevel = PlayerfabLoad.getPlayerLevelAfter();

        //Start loading scene async once enter loading screen
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad;
        if (playerCurrLevel == 0)
        {
            asyncLoad = SceneManager.LoadSceneAsync("Intro Cut Scene");    
        } else {
            asyncLoad = SceneManager.LoadSceneAsync("Level Selection");
        }
        
        //While loading
        while (asyncLoad.progress < 1)
        {
            progressBar.fillAmount = asyncLoad.progress;

            yield return new WaitForEndOfFrame(); //Waits for the frame to complete, before continuing with the code
        }
        
        //Finished loading
        yield return new WaitForEndOfFrame();
        
    }
}
