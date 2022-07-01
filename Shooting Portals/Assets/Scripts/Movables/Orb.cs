using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void removeOrb()
    {
        this.gameObject.SetActive(false);
    }
}
