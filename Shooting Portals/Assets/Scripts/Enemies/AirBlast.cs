using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents an air blast trap in Level 10
public class AirBlast : MonoBehaviour
{
    //Spawn Data
    [SerializeField] private int numberOfPositions; //Number of locations
    [SerializeField] private float[] spawnPositionsX = new float[3]; //Spawn locations x
    [SerializeField] private float[] spawnPositionsY = new float[3]; //Spawn locations y

    [SerializeField] private float respawnSpeed; //Speed of respawning

    [SerializeField] private float startTime;
    private Animator anim;





    private void Start()
    {
        anim = this.GetComponent<Animator>();
        InvokeRepeating("spawnAirBlast", startTime, respawnSpeed);
        
    }


    private void spawnAirBlast()
    {
        int targetLocation = Random.Range(0, numberOfPositions);
        this.transform.position = new Vector2(spawnPositionsX[targetLocation], spawnPositionsY[targetLocation]);
        anim.SetBool("appear", true);
    }


    private void deactivateAirBlast()
    {
        anim.SetBool("appear", false);
    }
}
