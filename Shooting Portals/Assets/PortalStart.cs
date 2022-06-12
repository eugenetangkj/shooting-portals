using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalStart : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] GameObject background;
    [SerializeField] GameObject canvas;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.haveCompletedLevel = true;
            player.GetComponent<Animator>().SetTrigger("cheerWithFade");
            background.GetComponent<Animator>().SetTrigger("appear");
            canvas.GetComponent<Animator>().SetTrigger("appear");
            Invoke("nextLevel", 3f);
        }
    }

    private void nextLevel()
    {
        SceneManager.LoadScene("Loading Screen Portal");
    }
}
