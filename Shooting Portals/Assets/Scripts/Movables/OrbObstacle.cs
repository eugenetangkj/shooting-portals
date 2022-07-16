using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents an active GameObject that will be set to inactive once all the collectibles in the array have been collected.
public class OrbObstacle : MonoBehaviour
{
    [SerializeField] private Orb[] orbs;
    private Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }


    // Update is called once per frame
    private void Update()
    {
        bool intermediateDisappear = true;
        foreach (Orb orb in orbs)
        {
            intermediateDisappear = intermediateDisappear && orb.hasTouched; //False as long as one collectible has yet to be collected.
        }
        if (intermediateDisappear)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            anim.SetTrigger("disappear");
            Invoke("obstacleDisappear", 1.01f);
        }
    }

    //Sets the current instance to be inactive in the scene
    private void obstacleDisappear()
    {
        this.gameObject.SetActive(false);
    }
}
