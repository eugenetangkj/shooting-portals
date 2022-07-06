using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOctopus : MonoBehaviour
{
    #region Octopus Variables
    public float maxHealth = 100;
    public float currentHealth;
    private Animator anim;
    private float[,] spawnPositions = new float[,]
        {
            {-14.36549f, -195.1223f}, //Spawn Position 1
            {12.18451f, -196.1523f}, //Spawn Position 2
            {39.22451f, -195.6023f}, //Spawn Position 3
            {64.8045f, -195.6023f}, //Spawn Position 4
            {91.1145f, -194.3523f}, //Spawn Position 5
            {116.6345f, -196.3123f}, //Spawn Position 6
            {142.0245f, -196.0923f}, //Spawn Position 7
            {166.0745f, -193.8223f} //Spawn Position 8
        };

    [SerializeField] private GameObject[] targets;

    //Targets
    [SerializeField] private float targetAppearDuration = 3f;
    [SerializeField] private float timeTakenForFirstTarget = 6f;
    [SerializeField] private float timeBetweenTargets = 5f;

    //Baby Octopuses
    [SerializeField] private float timeTakenForFirstBaby = 4f;
    [SerializeField] private float timeBetweenBabies = 10f;
    [SerializeField] private GameObject babyOctopus;
    [SerializeField] private Player player;



    //Enemy being damaged
    private bool currentlyHealing;
    [SerializeField] private GameObject hitAnimation;
    [SerializeField] private OctopusHealthBar healthBar;


    //Slime Blast
    [SerializeField] private GameObject slimeBlast;
    private int targetToSpawnSlimeBlast;


    //Spawn Moving Platforms
    [SerializeField] private GameObject[] movingPlatforms;






    #endregion

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = this.GetComponent<Animator>();
        currentlyHealing = false;
        
    }

    private void Update()
    {
        if (currentHealth == 90)
        {
            currentHealth = currentHealth - 0.00001f;
            makeOctopusDisappear();
            movingPlatforms[0].SetActive(true);
        }
        //TODO: Fill in the other health checkpoints
   
    }

    private void OnEnable()
    {
        anim.SetBool("disappear", false);
        currentlyHealing = false;
        InvokeRepeating("makeRandomTargetAppear", timeTakenForFirstTarget, timeBetweenTargets);
        InvokeRepeating("spawnBabyOctopus", timeTakenForFirstBaby, timeBetweenBabies);
    }

    private void makeRandomTargetAppear()
    {
        //Only let targets appear if boss octopus is not healing
        if (! currentlyHealing)
        {
            int targetToAppear = Random.Range(0, 2);
            targets[targetToAppear].SetActive(true);
            Invoke("makeTargetsDisappear", targetAppearDuration);
        }
        //Make targets disappear if boss octopus is healing
        else {
            makeTargetsDisappear();
        }
    }


    private void makeTargetsDisappear()
    {
        for (int i = 0; i < 2; i = i + 1)
        {
            targets[i].SetActive(false);
        }
    }

    private void spawnBossOctopus(int roomDetected)
    {
        int playerCheckpoint = PlayerfabLoad.getPlayerCheckPoint();

        this.transform.position = new Vector2(spawnPositions[playerCheckpoint, 0], spawnPositions[playerCheckpoint, 1]);
    }

    private void spawnBabyOctopus()
    {
        Vector2 spawnBabyOctopusPosition = new Vector2(this.transform.position.x - 3f, this.transform.position.y);
        GameObject babyOctopusSpawned =  Instantiate(babyOctopus, spawnBabyOctopusPosition, this.transform.rotation);
        babyOctopusSpawned.GetComponent<BabyOctopus>().setPlayer(player);
    }

    public void doDamage()
    {
        currentHealth = currentHealth - 2f;
        healthBar.SetHealth(currentHealth);

        Vector2 slimeBlastPos = new Vector2(this.transform.position.x - 1f, targets[targetToSpawnSlimeBlast].transform.position.y + 2f);
        GameObject slimeBlastSpawned = Instantiate(slimeBlast, slimeBlastPos, this.transform.rotation);
        slimeBlastSpawned.GetComponent<SlimeBlast>().shootTowardsPlayer(player);
        Debug.Log("Boss Health " + currentHealth);
    }


    public void addHealth()
    {
        currentHealth = currentHealth + 0.00001f;
    }

    public void activateHealing()
    {
        currentlyHealing = true;
        hitAnimation.SetActive(true);
        makeTargetsDisappear();
    }

    public void deactivateHealing()
    {
        currentlyHealing = false;
        anim.SetBool("hit", false);
        hitAnimation.SetActive(false);
    }

    public void setTargetSpawnArea(int targetNumber)
    {
        targetToSpawnSlimeBlast = targetNumber;
    }

    private void makeOctopusDisappear()
    {
        currentlyHealing = true;
        anim.SetBool("disappear", true);
    }

    private void despawnOctopus()
    {
        this.gameObject.SetActive(false);
    }



    




    /*
    Room 1: 5
    Room 2: 5
    Room 3: 6
    Room 4: 5
    Room 5: 7
    Room 6: 8
    Room 7: 7
    Room 8: 7

    Total: 50
    */
}
