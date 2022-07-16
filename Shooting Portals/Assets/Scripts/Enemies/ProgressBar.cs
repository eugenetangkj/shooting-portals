using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class represents a progress bar that tracks the distance between a GameObject's current x position
//and the destination's x position.
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] GameObject character;
    [SerializeField] private float originX;
    [SerializeField] private float destinationX;
    private float valuePerCoordinate; //How much to increase the progress bar by when character moves 1 unit


    void Start()
    {
        slider.maxValue = 100f;
        slider.value = 0f;
        valuePerCoordinate = 100f / (destinationX - originX);
        
    }

    void Update()
    {
        float progress = (character.transform.position.x - originX) * valuePerCoordinate;
        if (progress < 0f)
        {
            slider.value = 0f;
        } else {
            slider.value = progress;
        }
    }
}
