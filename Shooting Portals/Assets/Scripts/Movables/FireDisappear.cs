using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a parent game object whose child objects will all disappear and have their colliders removed if the player comes into contact with its collider.
public class FireDisappear : MonoBehaviour
{
    [SerializeField] GameObject lava;
    [SerializeField] GameObject fireBoat;
    [SerializeField] AudioSource soundEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundEffect.Play();
            //Make each child object disappear
            foreach (Transform child in lava.transform)
            {
                child.gameObject.GetComponent<Animator>().SetBool("disappear", true);
            }
            this.GetComponent<Animator>().SetTrigger("disappear");
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("destroyLava", 2f);
        }
        
    }

    //Set itself and all the children to inactive in scene
    private void destroyLava()
    {
        lava.SetActive(false);
        fireBoat.SetActive(true);
    }

}
