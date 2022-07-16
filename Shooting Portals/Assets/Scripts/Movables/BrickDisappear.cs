using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents an object that will make another GameObject disappear and set it to be inactive in the scene if the player enter its own collider.
public class BrickDisappear : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    [SerializeField] private AudioSource soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundEffect.Play();
            brick.GetComponent<Animator>().SetTrigger("disappear");
            this.GetComponent<Animator>().SetTrigger("disappear");
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("destroyBrick", 2f);
        }  
    }

    private void destroyBrick()
    {
        brick.SetActive(false);
    }
}
