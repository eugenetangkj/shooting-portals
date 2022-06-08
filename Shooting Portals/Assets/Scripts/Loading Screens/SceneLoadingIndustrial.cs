using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class SceneLoadingIndustrial : SceneLoading
{
    [SerializeField] private Image progressBar;
    
    public override void Start()
    {
        base.Start();
    }

    protected override IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad;
        if (PlayerfabLoad.playerLevelSelected == "Level 1 Cutscene")
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 1 Intro Cutscene");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 1" )
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 1");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 2") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 2");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 2 Cutscene") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 2 Cutscene");
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