using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

//This class plays the associated timeline 4 seconds after it is instantiated.
public class PlayTransition : MonoBehaviour
{
    [SerializeField] PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartTimeline", 4f);
    }
    private void StartTimeline()
    {
        director.Play();
    }
}

