using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a spring which would propel the player upwards
public class SpringNew : MonoBehaviour
{
    #region Spring Data
    [SerializeField] private Player player;
    [SerializeField] private AudioSource springSound;
    [SerializeField] private float jumpDistance;
    #endregion


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            springSound.Play();
            this.GetComponent<Animator>().SetBool("activated", true);
            player.setVelocityY(jumpDistance); //Propels player upwards
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("setAnim", 0.1f);
        }
    }

    private void setAnim()
    {
        this.GetComponent<Animator>().SetBool("activated", false);

    }

}