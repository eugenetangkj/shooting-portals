using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a leaf used in the collectible puzzle of Level 4 
public class LeafElevator : MonoBehaviour
{
    #region Leaf Data
    [SerializeField] private GameObject nextToAppear;
    [SerializeField] private AudioSource audioEffect;
    private Animator anim;
    #endregion
    
    #region Main Methods
    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("disappear", true);
            audioEffect.Play();
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("removeObject", 1.01f);
            nextToAppear.SetActive(true); //Sets the next leaf to be active
        }
    }
    #endregion

    #region Leaf Methods
    //Sets itself to inactive in scene
    private void removeObject()
    {
        this.gameObject.SetActive(false);
    }
    #endregion


}
