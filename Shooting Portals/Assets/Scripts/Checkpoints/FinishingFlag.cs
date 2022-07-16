using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a finishing flag in a level.
public class FinishingFlag : MonoBehaviour
{
    #region Finishing Flag Data
    [SerializeField] private Player player;
    [SerializeField] private Animator levelCompleteWords;
    [SerializeField] private LevelComplete levelComplete;
    [SerializeField] private Animator transition;

    private bool hasFinishedBefore = false;

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ! hasFinishedBefore)
        {
            hasFinishedBefore = true;
            player.haveCompletedLevel = true;
            player.GetComponent<Animator>().SetTrigger("cheer");
            player.levelCompletedSound.Play();
            levelCompleteWords.SetTrigger("appear");
            transition.SetTrigger("fadeOut");
            Invoke("goToNextLevel", 8.5f);
        }
    }

    //Starts to load the next scene accordingly
    private void goToNextLevel()
    {
        levelComplete.completeLevel();
    }
}
