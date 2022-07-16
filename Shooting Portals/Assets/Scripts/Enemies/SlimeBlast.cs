using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a slime blast, which is an attack by the Boss Octopus in Level 10
public class SlimeBlast : MonoBehaviour
{
    #region SlimeBlast Data
    [SerializeField] private float slimeBlastSpeed;
    [SerializeField] private float slimeBlastLifeSpan;
    private Player playerInScene;
    private Vector2 targetDestination;

    #endregion

    #region Main Methods
    private void Start()
    {
        Invoke("playDestroySlimeBlastAnimation", slimeBlastLifeSpan - 0.8f);
        Invoke("destroySlimeBlast", slimeBlastLifeSpan); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInScene.StateMachine.ChangeState(playerInScene.DeathState);
        }
    }
    #endregion

    #region SlimeBlast Data
    
    //Sets the slime blast moving horizontally
    public void shootTowardsPlayer(Player player)
    {
        playerInScene = player;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-slimeBlastSpeed, 0f);
    }

    //Sets the destroy animation for slimeblast
    private void playDestroySlimeBlastAnimation()
    {
        this.GetComponent<Animator>().SetTrigger("destroy");
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    //Destroys the slimeblast instance
    private void destroySlimeBlast()
    {
        Destroy(this);

    }
    
    #endregion
}
