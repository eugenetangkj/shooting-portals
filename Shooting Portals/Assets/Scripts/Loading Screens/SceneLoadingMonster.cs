using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

//This class handles the scene transitions for levels associated with the Monster Loading Screen.
public class SceneLoadingMonster : SceneLoading
{
    [SerializeField] private Image progressBar;
    
    public override void Start()
    {
        base.Start();
    }

    protected override IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad;
        if (PlayerfabLoad.playerLevelSelected == "Level 9 Cutscene")
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 9 Cutscene");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 9" )
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 9");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 10 Pre Cutscene") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 10 Pre Cutscene");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 10") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 10");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 10 Post Cutscene") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 10 Post Cutscene");
        }
        else //PlayerfabLoad.playerLevelSelected == "Level Selection"
        {
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