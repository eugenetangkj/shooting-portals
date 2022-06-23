using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
