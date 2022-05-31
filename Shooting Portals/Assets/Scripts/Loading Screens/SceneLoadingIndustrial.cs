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
        Debug.Log(PlayerfabLoad.playerLevelSelected);
        base.Start();
    }

    protected override IEnumerator LoadAsyncScene()
    {
        Debug.Log(PlayerfabLoad.playerLevelSelected);
        AsyncOperation asyncLoad;
        if (PlayerfabLoad.playerLevelSelected == 1)
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 1 Intro Cutscene");    
        } else {
            asyncLoad = SceneManager.LoadSceneAsync("Level 1");
        }
        //TODO: Insert else-if for level 2 transitions
        
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