using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public abstract class SceneLoading : MonoBehaviour
{
    protected int playerCurrLevel;
    

    public virtual void Start()
    {
        //Gets player's current level to decide which scene to transition into
        playerCurrLevel = PlayerfabLoad.getPlayerLevelAfter();

        //Start loading scene async once enter loading screen
        StartCoroutine(LoadAsyncScene());
    }

    protected abstract IEnumerator LoadAsyncScene();
}
