using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will make a GameObject inactive, and another active in scene if the player enters its vicinity.
public class WheelTransition : MonoBehaviour
{
    [SerializeField] private GameObject trapDisappear;
    [SerializeField] private GameObject trapAppear;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trapDisappear.SetActive(false);
            trapAppear.SetActive(true);
        }
    }
}
