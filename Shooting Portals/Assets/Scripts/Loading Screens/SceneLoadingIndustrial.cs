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
        if (PlayerfabLoad.playerLevelSelected == 1f)
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level Selection");
        }
        else if (PlayerfabLoad.playerLevelSelected == 1.1f)
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 1 Intro Cutscene");    
        }
        else if (PlayerfabLoad.playerLevelSelected == 1.2f) {
            asyncLoad = SceneManager.LoadSceneAsync("Level 1");
        }
        else if (PlayerfabLoad.playerLevelSelected == 2f) {
            asyncLoad = SceneManager.LoadSceneAsync("Level Selection");
        }
        else if (PlayerfabLoad.playerLevelSelected == 2.1f)
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 2");
        } else if (PlayerfabLoad.playerLevelSelected == 2.2f) {
            asyncLoad = SceneManager.LoadSceneAsync("Level 2 Cutscene");
        } else
        {
            asyncLoad = SceneManager.LoadSceneAsync("Login Menu"); //To be updated again next time
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