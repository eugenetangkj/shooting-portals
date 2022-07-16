using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a leaf used in the collectible puzzle of Level 3
public class LeafCollectible : MonoBehaviour
{
    #region Leaf Data
    public static float startTime;
    public bool hasTaken {get; private set;}
    private Animator anim;
    public static bool newSet = true;
    [SerializeField] private AudioSource collectAudio;
    #endregion

    #region Main Methods
    private void Start()
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

    #endregion

    #region Leaf Methods
    //Makes the leaf appear
    public void makeLeafAppear()
    {
        if (hasTaken)
        {
        anim.SetBool("disappear", false);
        hasTaken = false;
        }    
    }
    #endregion
}
