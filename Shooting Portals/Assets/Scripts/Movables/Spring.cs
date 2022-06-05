using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private AudioSource springSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            springSound.Play();
            player.setVelocityY(26f);
        }
    }
}