using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafElevator : MonoBehaviour
{
    [SerializeField] private GameObject nextToAppear;
    [SerializeField] private AudioSource audioEffect;
    private Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        anim = this.GetComponent<Animator>();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("reached1");
        if (collision.tag == "Player")
        {
            Debug.Log("reached");
            anim.SetBool("disappear", true);
            audioEffect.Play();
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("removeObject", 1.01f);
            nextToAppear.SetActive(true);
        }
    }

    private void removeObject()
    {
        this.gameObject.SetActive(false);
    }


}
