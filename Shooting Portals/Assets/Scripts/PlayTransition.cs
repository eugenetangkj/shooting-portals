using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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

