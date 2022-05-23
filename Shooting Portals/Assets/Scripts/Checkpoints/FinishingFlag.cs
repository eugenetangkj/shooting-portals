using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingFlag : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Animator levelCompleteWords;
    [SerializeField] private LevelComplete levelComplete;
    [SerializeField] private Animator transition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Animator>().SetTrigger("cheer");
            player.levelCompletedSound.Play();
            levelCompleteWords.SetTrigger("appear");
            transition.SetTrigger("fadeOut");
            Invoke("goToNextLevel", 8.5f);
        }
    }

    private void goToNextLevel()
    {
        levelComplete.completeLevel();
    }
}
