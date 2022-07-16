using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class represents the Boss Octopus in Level 10.
    Health distribution:
    Room 1: 5
    Room 2: 5
    Room 3: 6
    Room 4: 5
    Room 5: 7
    Room 6: 8
    Room 7: 7
    Room 8: 7
    Total: 50

    Each hit is worth 2 health.
*/
public class BossOctopus : MonoBehaviour
{
    #region Octopus Variables
    public float maxHealth = 100;
    public float currentHealth;
    private Animator anim;


    //Spawning
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
    
    private int[] healthValues = new int[] {100, 90, 80, 68, 58, 44, 28, 14};


    private int numberOfHits = 0;
    private int playerCheckpoint;

    private bool isAlive;

    public int bossCheckpoint {get; private set;}


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
    [SerializeField] private AudioSource bossHit;


    //Slime Blast
    [SerializeField] private GameObject slimeBlast;
    private int targetToSpawnSlimeBlast;


    //Spawn Moving Platforms
    [SerializeField] private GameObject[] movingPlatforms;






    #endregion

    #region Main Methods
    private void Awake()
    {
        anim = this.GetComponent<Animator>();
        currentlyHealing = false;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (playerCheckpoint == 0 && numberOfHits == 5 && isAlive) //Room 1
        {
            makeTargetsDisappear();
            makeOctopusDisappear();
            movingPlatforms[0].SetActive(true);
            playerCheckpoint += playerCheckpoint + 1;
        }
        else if (playerCheckpoint == 1 && numberOfHits == 5 && isAlive) //Room 2
        {
            makeTargetsDisappear();
            makeOctopusDisappear();
            movingPlatforms[1].SetActive(true); 
        }
        else if (playerCheckpoint == 2 && numberOfHits == 6 && isAlive) //Room 3
        {
            makeTargetsDisappear();
            makeOctopusDisappear();
            movingPlatforms[2].SetActive(true); 
        }
        else if (playerCheckpoint == 3 && numberOfHits == 5 && isAlive) //Room 4
        {
            makeTargetsDisappear();
            makeOctopusDisappear();
            movingPlatforms[3].SetActive(true); 
        }
        else if (playerCheckpoint == 4 && numberOfHits == 7 && isAlive) //Room 5
        {
            makeTargetsDisappear();
            makeOctopusDisappear();
            movingPlatforms[4].SetActive(true); 
        }
        else if (playerCheckpoint == 5 && numberOfHits == 8 && isAlive) //Room 6
        {
            makeTargetsDisappear();
            makeOctopusDisappear();
            movingPlatforms[5].SetActive(true); 
        }
        else if (playerCheckpoint == 6 && numberOfHits == 7 && isAlive) // Room 7
        {
            makeTargetsDisappear();
            makeOctopusDisappear();
            movingPlatforms[6].SetActive(true); 
        }
        else if (playerCheckpoint == 7 && numberOfHits == 7 && isAlive) //Room 8
        {
            makeTargetsDisappear();
            makeOctopusDisappear();
            movingPlatforms[7].SetActive(true); 
        }
    }

    private void OnEnable()
    {
        isAlive = true;
        numberOfHits = 0;
        playerCheckpoint = PlayerfabLoad.getPlayerCheckPoint();
        bossCheckpoint = playerCheckpoint;
        currentHealth = healthValues[playerCheckpoint];
        healthBar.SetHealth(currentHealth);
        anim.SetBool("disappear", false);
        anim.SetBool("hit", false);
        currentlyHealing = false;
        InvokeRepeating("makeRandomTargetAppear", timeTakenForFirstTarget, timeBetweenTargets);
        InvokeRepeating("spawnBabyOctopus", timeTakenForFirstBaby, timeBetweenBabies);
    }
    #endregion

    #region Boss Octopus Methods

    //Randomly generates the vital points and targets on the Boss Octopus
    private void makeRandomTargetAppear()
    {
        //Only let targets appear if boss octopus is not healing
        if (! currentlyHealing && isAlive)
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

    //Causes all vital points and targets on the Boss Octopus to disappear
    private void makeTargetsDisappear()
    {
        for (int i = 0; i < 2; i = i + 1)
        {
            targets[i].SetActive(false);
        }
    }

    //Spawns the Boss Octopus in the corresponding room
    public void spawnBossOctopus(int roomDetected)
    {
        this.transform.position = new Vector2(spawnPositions[roomDetected - 1, 0], spawnPositions[roomDetected - 1, 1]);
    }

    
    //Spawns a Baby Octopus instance
    private void spawnBabyOctopus()
    {
        Vector2 spawnBabyOctopusPosition = new Vector2(this.transform.position.x - 3f, this.transform.position.y);
        GameObject babyOctopusSpawned =  Instantiate(babyOctopus, spawnBabyOctopusPosition, this.transform.rotation);
        babyOctopusSpawned.GetComponent<BabyOctopus>().setPlayer(player);
    }

    //Does damage to the Boss Octopus
    public void doDamage()
    {
        bossHit.Play();
        currentHealth = currentHealth - 2f;
        healthBar.SetHealth(currentHealth);

        Vector2 slimeBlastPos = new Vector2(this.transform.position.x - 1f, targets[targetToSpawnSlimeBlast].transform.position.y + 2f);
        GameObject slimeBlastSpawned = Instantiate(slimeBlast, slimeBlastPos, this.transform.rotation);
        slimeBlastSpawned.GetComponent<SlimeBlast>().shootTowardsPlayer(player);
    }

    //Boss octopus has been hit, so this method prevents player from attacking it while it is recovering
    public void activateHealing()
    {
        currentlyHealing = true;
        hitAnimation.SetActive(true);
        makeTargetsDisappear();
    }

    //Boss octopus has recovered and this method allows player to start hitting it again
    public void deactivateHealing()
    {
        currentlyHealing = false;
        anim.SetBool("hit", false);
        hitAnimation.SetActive(false);
    }

    //Sets the position for the slimeblast to be created, either at the position of target 1 or target 2
    //depending on where the player has shot
    public void setTargetSpawnArea(int targetNumber)
    {
        targetToSpawnSlimeBlast = targetNumber;
    }


    //Causes the octopus to disappear. If health is not yet 0, the boss octopus will spawn in the next room. 
    //If health is 0, boss octopus will no longer spawn.
    private void makeOctopusDisappear()
    {
        if (currentHealth != 0)
        {
        bossCheckpoint += 1;
        isAlive = false;
        currentlyHealing = true;
        anim.SetBool("hit", false);
        anim.SetBool("disappear", true);
        }
        else if (currentHealth == 0)
        {
            bossCheckpoint += 1;
            isAlive = false;
            currentlyHealing = true;
            anim.SetBool("hit", false);
            anim.SetTrigger("death");
        }
    }

    //Despawns the Boss Octopus
    private void despawnOctopus()
    {
        this.gameObject.SetActive(false);
        CancelInvoke();
    }

    //Keeps track of the number of hits that the Boss Octopus has suffered thus far
    public void increaseHit()
    {
        this.numberOfHits += 1;
    }
    #endregion
    
}
