using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents an instance that would disappear if all the GameObjects in activeObjects are active in scene
public class CheckActive : MonoBehaviour
{
    [SerializeField] private GameObject[] activeObjects;
    private Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }


    private void Update()
    {
        bool allActive = true;
        foreach (GameObject activeObject in activeObjects)
        {
            allActive = allActive && (activeObject == null);
        }
        if (allActive)
        {
            anim.SetTrigger("disappear");
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("makeObstacleDisappear", 1.1f);
        }
    }

    private void makeObstacleDisappear()
    {
        this.gameObject.SetActive(false);
    }
}
