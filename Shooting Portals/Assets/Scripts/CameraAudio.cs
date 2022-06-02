using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
