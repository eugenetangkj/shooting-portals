using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] GameObject character;
    [SerializeField] private float originX;
    [SerializeField] private float destinationX;
    private float valuePerCoordinate; //How much to increase the progress bar by when character moves 1 unit


    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 100f;
        slider.value = 0f;
        valuePerCoordinate = 100f / (destinationX - originX);
        
    }

    // Update is called once per frame
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
