using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafElevatorFinal : MonoBehaviour
{
    [SerializeField] private GameObject barrier;
    [SerializeField] private AudioSource audioEffect;
    private Animator anim;


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
                child.gameObject.GetComponent<Animator>().SetBool("disappear", true);
            }
            Invoke("removeBarrier", 1.01f);

        }
    }

    private void removeBarrier()
    {
        this.gameObject.SetActive(false);
        barrier.SetActive(false);
    }
}
