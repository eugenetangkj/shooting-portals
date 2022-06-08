using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void navigateToNew()
    {
        SceneManager.LoadScene("New Player Login");
    }

    public void navigateToExisting()
    {
        SceneManager.LoadScene("Existing Player Login");
    }
}
