using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a collectible that the player can touch in order to make it disappear.
public class Orb : MonoBehaviour
{
    public bool hasTouched {get; private set;}
    private Animator anim;
    [SerializeField] private AudioSource audioSound;

    private void Start()
    {
        hasTouched = false;
        anim = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ! hasTouched)
        {
            audioSound.Play();
            hasTouched = true;
            anim.SetTrigger("disappear");
            Invoke("removeOrb", 1.01f);
        }
    }

    //Sets this collectible to be inactive in the scene.
    private void removeOrb()
    {
        this.gameObject.SetActive(false);
    }
}
