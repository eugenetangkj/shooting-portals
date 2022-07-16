using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class handles the logic for the Introduction Scene.
public class Introduction : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("nextLevel", 4f);
        
    }

    //Loads the Login Menu after the Introduction Scene.
    private void nextLevel()
    {
        SceneManager.LoadScene("Login Menu New");
    }
}
