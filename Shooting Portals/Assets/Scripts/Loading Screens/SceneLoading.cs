using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

//This class is an abstract class that handles the logic for loading screens. Its child classes will handle the corresponding
//transitions depending on the levels that they are responsible for.
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
