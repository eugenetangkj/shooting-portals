using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWheel : MonoBehaviour
{
    private Vector2 originalPos;
    private bool shouldReset;
    [SerializeField] float wheelHorizontalSpeed = 4f;
    [SerializeField] float wheelStartTime = 6f;
    [SerializeField] float wheelTravelDuration = 6f;
    void Start()
    {
        originalPos = this.transform.position;
        shouldReset = true;
        InvokeRepeating("toggleShouldReset", wheelStartTime, wheelTravelDuration);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldReset)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            this.transform.position = originalPos;
        } else {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(- wheelHorizontalSpeed, 0f);
        }
    }

    private void toggleShouldReset()
    {
        shouldReset = (shouldReset) ? false : true;
    }
}
