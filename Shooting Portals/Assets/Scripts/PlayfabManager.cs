using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    //To associate the corresponding buttons and fields
    [SerializeField] private GameObject messageText;

    [SerializeField] private GameObject emailInput;
    [SerializeField] private GameObject passwordInput;

    //Variables containing the content of the buttons and fields
    private string message;
    private string email;
    private string password;

    public void Start() {
        message = messageText.GetComponent<TextMeshProUGUI>().text;
        email = emailInput.GetComponent<TMP_InputField>().text;
        password = passwordInput.GetComponent<TMP_InputField>().text;
    }

    public void RegisterButton()
    {
        if (passwordInput.GetComponent<TMP_InputField>().text.Length < 6)
        {
            messageText.GetComponent<TextMeshProUGUI>().text = "Minimum 6 characters for password";
            return;
        }
        else if (passwordInput.GetComponent<TMP_InputField>().text.Length > 100)
        {
            messageText.GetComponent<TextMeshProUGUI>().text = "Maximum 100 characters for password";
            return;
        }

        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.GetComponent<TMP_InputField>().text,
            Password = passwordInput.GetComponent<TMP_InputField>().text,
            RequireBothUsernameAndEmail = false //Can register without username field
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    } 

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        //When a user registers, Playfab automatically logs in so we can directly call another API request
        messageText.GetComponent<TextMeshProUGUI>().text = "Registered and logged in";
    }

    public void LoginButton()
    {
        if (passwordInput.GetComponent<TMP_InputField>().text.Length < 6 ||
            passwordInput.GetComponent<TMP_InputField>().text.Length > 100)
        {
            messageText.GetComponent<TextMeshProUGUI>().text = "Invalid email address or password";
            return;
        }

        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.GetComponent<TMP_InputField>().text,
            Password = passwordInput.GetComponent<TMP_InputField>().text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        messageText.GetComponent<TextMeshProUGUI>().text = "Logged in";
        Debug.Log("Successful login/account created");
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest {
            Email = emailInput.GetComponent<TMP_InputField>().text,
            TitleId = "FE2BA"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    private void OnPasswordReset(SendAccountRecoveryEmailResult result) {
        messageText.GetComponent<TextMeshProUGUI>().text = "Check email to reset password";
    }

    private void OnError(PlayFabError error)
    {
        messageText.GetComponent<TextMeshProUGUI>().text = error.ErrorMessage;
        Debug.Log("Error while logging in/creating account");
        Debug.Log(error.GenerateErrorReport());
    }
}