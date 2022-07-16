using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents the final leaf object used in the collectible puzzle of Level 4
public class LeafElevatorFinal : MonoBehaviour
{
    #region Leaf Data
    [SerializeField] private GameObject barrier;
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
            foreach (Transform child in barrier.transform)
            {
                child.gameObject.GetComponent<Animator>().SetBool("disappear", true); //Make barriers disappear
            }
            Invoke("removeBarrier", 1.01f);

        }
    }
    #endregion

    #region Leaf Methods
    //Removes the barrier obstacle
    private void removeBarrier()
    {
        this.gameObject.SetActive(false);
        barrier.SetActive(false);
    }
    #endregion
}
