using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

//This class handles the scene transitions for levels associated with the Forest Loading Screen.
public class SceneLoadingForest : SceneLoading
{
    [SerializeField] private Image progressBar;
    
    public override void Start()
    {
        base.Start();
    }

    protected override IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad;
        if (PlayerfabLoad.playerLevelSelected == "Level 3 Cutscene")
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 3 Cutscene");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 3" )
        {
            asyncLoad = SceneManager.LoadSceneAsync("Level 3");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 4") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 4");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 5") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 5");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 5 Pre Cutscene") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 5 Pre Cutscene");
        }
        else if (PlayerfabLoad.playerLevelSelected == "Level 5 Post Cutscene") {
            asyncLoad = SceneManager.LoadSceneAsync("Level 5 Post Cutscene");
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