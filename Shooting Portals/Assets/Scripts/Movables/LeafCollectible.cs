using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafCollectible : MonoBehaviour
{
    public static float startTime;
    public bool hasTaken {get; private set;}
    private Animator anim;
    public static bool newSet = true;
    [SerializeField] private AudioSource collectAudio;

    void Start()
    {
        hasTaken = false;
        anim = this.GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (newSet)
            {
                startTime = Time.time;
                newSet = false;
            }
            collectAudio.Play();
            anim.SetBool("disappear", true);
            hasTaken = true;
        }
    }

    public void makeLeafAppear()
    {
        if (hasTaken)
        {
        anim.SetBool("disappear", false);
        hasTaken = false;
        }    
    }
}
