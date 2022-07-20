using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class is responsible for transition between the Start Screen and Level Selection
public class PortalStart : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject canvas;
    
    public void goNextLevel()
    {
        player.GetComponent<Animator>().SetTrigger("disappear");
        background.GetComponent<Animator>().SetTrigger("appear");
        canvas.GetComponent<Animator>().SetTrigger("appear");
        Invoke("nextLevel", 2f);
    }

    private void nextLevel()
    {
        SceneManager.LoadScene("Loading Screen Portal");
    }

}
