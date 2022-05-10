using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{
    //To obtain the content from the buttons and fields
    [SerializeField] private GameObject messageText;
    [SerializeField] private GameObject emailInput;
    [SerializeField] private GameObject passwordInput;


    //To trigger animations
    [SerializeField] private GameObject dog;
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject starOne;
    [SerializeField] private GameObject starTwo;
    [SerializeField] private GameObject canvas;


    //Functionality for Register Button
    public void RegisterButton()
    {
        //Invalid password lengths
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

        //Send API request to register user
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.GetComponent<TMP_InputField>().text,
            Password = passwordInput.GetComponent<TMP_InputField>().text,
            RequireBothUsernameAndEmail = false //Can register without username field
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    } 

    //Action after successful registration
    //Note that when a user registers, Playfab automatically logs in so we can directly call another API request after registration
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.GetComponent<TextMeshProUGUI>().text = "Registered and logged in";
        Invoke("nextLevel", 2f);
    }

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
        //Debug.Log("Successful login/account created");
        //Trigger fade out
        dog.GetComponent<Animator>().SetTrigger("disappear");
        rock.GetComponent<Animator>().SetTrigger("disappear");
        starOne.GetComponent<Animator>().SetTrigger("disappear");
        starTwo.GetComponent<Animator>().SetTrigger("disappear");
        canvas.GetComponent<Animator>().SetTrigger("disappear");
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}