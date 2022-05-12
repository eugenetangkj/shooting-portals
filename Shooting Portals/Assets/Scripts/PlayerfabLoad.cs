using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

//This class handles API requests to get and/or update player's level
//as the player progresses through the game.
public class PlayerfabLoad : MonoBehaviour
{

    //Player's level
    private static int playerLevel;
    
    //Gets the player's current level when user first logs in
    public static int getPlayerLevelBefore()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(){
            Keys = null
            }, userDataSuccess, onError);
        return PlayerfabLoad.playerLevel;
    }

    //Set player's level to 0 if player's data does not exist,
    //otherwise updates playerLevel to the correct value.
    public static void userDataSuccess(GetUserDataResult results)
    {
        if (results.Data == null || ! results.Data.ContainsKey("PlayerLevel"))
        {
            //No level data, so we set level to be 0
            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
                Data = new Dictionary<string, string>(){{"PlayerLevel", "0"}}
                }, setDataSuccess, onError); 
            PlayerfabLoad.playerLevel = 0;  
        }

        else
        {
            //Level data exists, so we get the player's level data.
            int currentLevel = int.Parse(results.Data["PlayerLevel"].Value);
            PlayerfabLoad.playerLevel = currentLevel;
        }
    }

    public static int getPlayerLevelAfter()
    {
        return PlayerfabLoad.playerLevel;
    }


    //Updates the player's level
    public static void updatePlayerLevel(string levelToUse)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
            Data = new Dictionary<string, string>(){{"PlayerLevel", levelToUse}}
            }, setDataSuccess, onError);
        PlayerfabLoad.playerLevel = int.Parse(levelToUse);
    }

    //Runs when player's level data is updated successfully
    private static void setDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Player's level updated successfully.");
    }

    //Outputs error message if any API request is unsuccessful
    private static void onError(PlayFabError error)
    {
        Debug.Log(error);
    }
}

    

