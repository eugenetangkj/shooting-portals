using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class wil pause the background music if the game is paused, and resumes it otherwise
public class CameraAudio : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;


    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isGamePaused)
        {
            backgroundMusic.Pause();
        } else
        {
            backgroundMusic.UnPause();
        }
    }
}
