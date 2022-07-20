using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class activates the Tutorial Prompt if player enters the vicinity
public class TutorialSpaceBar : MonoBehaviour
{
    [SerializeField] private GameObject tutorialObject;
    private Animator anim;

    private void Start()
    {
        anim = tutorialObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (! tutorialObject.activeInHierarchy)
            {
                tutorialObject.SetActive(true);
                anim.SetBool("appear", true);
            }
            else {
            anim.SetBool("appear", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("appear", false);
        }
    }
}

