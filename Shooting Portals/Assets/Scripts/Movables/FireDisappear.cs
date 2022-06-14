using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDisappear : MonoBehaviour
{
    [SerializeField] GameObject lava;
    [SerializeField] GameObject fireBoat;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (Transform child in lava.transform)
            {
                child.gameObject.GetComponent<Animator>().SetBool("disappear", true);
            }
            this.GetComponent<Animator>().SetTrigger("disappear");
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("destroyLava", 2f);
        }
        
    }


    private void destroyLava()
    {
        lava.SetActive(false);
        fireBoat.SetActive(true);
    }

}
