using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ExistingPlayerLogin : MonoBehaviour
{
    //To obtain the content from the buttons and fields
    [SerializeField] private GameObject messageText;
    [SerializeField] private GameObject emailInput;
    [SerializeField] private GameObject passwordInput;


    //Functionality for Login Button
    public void LoginButton()
    {
        //Invalid password lengths, hence confirm incorrect password
        if (passwordInput.GetComponent<TMP_InputField>().text.Length < 6 ||
            passwordInput.GetComponent<TMP_InputField>().text.Length > 100)
        {
            messageText.GetComponent<TextMeshProUGUI>().text = "Invalid email address or password";
            return;
        }

        //Send API request to login
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.GetComponent<TMP_InputField>().text,
            Password = passwordInput.GetComponent<TMP_InputField>().text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    //Action after successful login
    private void OnLoginSuccess(LoginResult result)
    {
        messageText.GetComponent<TextMeshProUGUI>().text = "Logged in";
        Invoke("nextLevel", 2f);
    }

    //Functionality for Reset Password Button
    public void ResetPasswordButton()
    {
        //Send API request to reset password
        var request = new SendAccountRecoveryEmailRequest {
            Email = emailInput.GetComponent<TMP_InputField>().text,
            TitleId = "FE2BA"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    //Action after requesting for password change
    private void OnPasswordReset(SendAccountRecoveryEmailResult result) {
        messageText.GetComponent<TextMeshProUGUI>().text = "Check email to reset password";
    }
    
    //Action to carry out if there is an error
    private void OnError(PlayFabError error)
    {
        messageText.GetComponent<TextMeshProUGUI>().text = error.ErrorMessage;
        //Debug.Log("Error while logging in/creating account");
        //Debug.Log(error.GenerateErrorReport());
    }

    //Transit to next level
    private void nextLevel()
    {
        SceneManager.LoadScene("Start Screen");
    }
}