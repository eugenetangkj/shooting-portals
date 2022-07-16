using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class handles the transition into either "New Player Login" or "Existing Player Login" scenes, depending on the profile that the player selects
public class NewOrExistingPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerSelection;
    [SerializeField] private GameObject transition;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("appear", 1f);
        
    }

    private void appear()
    {
        playerSelection.SetActive(true);
        Destroy(transition);
    }

    //Transitions into "New Player Login" scene
    public void navigateToNew()
    {
        SceneManager.LoadScene("New Player Login");
    }

    //Transitions into "Existing Player Login" scene
    public void navigateToExisting()
    {
        SceneManager.LoadScene("Existing Player Login");
    }
}
