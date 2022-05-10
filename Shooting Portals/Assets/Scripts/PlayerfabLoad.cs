using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerfabLoad : MonoBehaviour
{
    
    private void Start()
    {
        getPlayerData();
    }

    private void getPlayerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(){
            Keys = null
        }, userDataSuccess, onError);
    }

    private void userDataSuccess(GetUserDataResult results)
    {
        if (results.Data == null || ! results.Data.ContainsKey("PlayerLevel"))
        {
            //No save info
            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
                Data = new Dictionary<string, string>(){{"PlayerLevel", "0"}}
                }, setDataSuccess, onError);     
        }
        
        else
        {
            //Save info, load level
            Debug.Log(int.Parse(results.Data["PlayerLevel"].Value) + 1);
        }
    }

    private void setDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Saved current");
    }

    private void onError(PlayFabError error)
    {
        Debug.Log(error);
    }
}
      
    
