using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class SceneLoadingElemental : SceneLoading
{
    [SerializeField] private Image progressBar;
    
    public override void Start()
    {
        base.Start();
    }

    protected override IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad;
        if (PlayerfabLoad.playerLevelSelected == "Level 6 Cutscene")
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 6 Cutscene");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 6" )
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 6");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 7") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 7");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 8 Pre Cutscene") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 8 Pre Cutscene");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 8") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 8");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 8 Post Cutscene") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 8 Post Cutscene");
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