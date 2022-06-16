using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
