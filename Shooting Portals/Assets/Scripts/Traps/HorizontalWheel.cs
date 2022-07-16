using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents the horizontally-moving trap wheels in Level 5
public class HorizontalWheel : MonoBehaviour
{
    #region Wheel Data
    private Vector2 originalPos;
    private bool shouldReset;
    [SerializeField] private float wheelHorizontalSpeed = 4f;
    [SerializeField] private float wheelStartTime = 6f; //Time at which wheel will start moving after reseting at original position
    [SerializeField] private float wheelTravelDuration = 6f; //Time for which wheel will move horizontally before reseting

    #endregion

    private void Start()
    {
        originalPos = this.transform.position;
        shouldReset = true;
        InvokeRepeating("toggleShouldReset", wheelStartTime, wheelTravelDuration);
    }

    // Update is called once per frame
    private void Update()
    {
        if (shouldReset)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f); //Sets wheel stationary
            this.transform.position = originalPos; //Restores wheel to original position
        } else {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(- wheelHorizontalSpeed, 0f); //Moves wheel horizontally
        }
    }

    //Resets the wheel to the original position when necessary
    private void toggleShouldReset()
    {
        shouldReset = (shouldReset) ? false : true;
    }

}
