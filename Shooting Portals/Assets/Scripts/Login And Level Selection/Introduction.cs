using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("nextLevel", 4f);
        
    }

    private void nextLevel()
    {
        SceneManager.LoadScene("Login Menu New");
    }
}
