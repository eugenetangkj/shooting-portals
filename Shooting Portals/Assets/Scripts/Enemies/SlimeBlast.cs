using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBlast : MonoBehaviour
{
    [SerializeField] private float slimeBlastSpeed;
    [SerializeField] private float slimeBlastLifeSpan;
    private Player playerInScene;
    private Vector2 targetDestination;


    // Start is called before the first frame update
    private void Start()
    {
        Invoke("playDestroySlimeBlastAnimation", slimeBlastLifeSpan - 0.8f);
        Invoke("destroySlimeBlast", slimeBlastLifeSpan);
        
    }

  


    public void shootTowardsPlayer(Player player)
    {
        playerInScene = player;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-slimeBlastSpeed, 0f);
    }

    private void playDestroySlimeBlastAnimation()
    {
        this.GetComponent<Animator>().SetTrigger("destroy");
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void destroySlimeBlast()
    {
        Destroy(this);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInScene.StateMachine.ChangeState(playerInScene.DeathState);
        }
    }

}
