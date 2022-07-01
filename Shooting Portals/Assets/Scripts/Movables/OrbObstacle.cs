using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbObstacle : MonoBehaviour
{
    [SerializeField] private Orb[] orbs;
    private Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        bool intermediateDisappear = true;
        foreach (Orb orb in orbs)
        {
            intermediateDisappear = intermediateDisappear && orb.hasTouched;
        }
        if (intermediateDisappear)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            anim.SetTrigger("disappear");
            Invoke("obstacleDisappear", 1.01f);
        }
    }

    private void obstacleDisappear()
    {
        this.gameObject.SetActive(false);
    }
}
