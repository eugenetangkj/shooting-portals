using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the logic for the collectible puzzle in level 3. It activates the platform if all 3 leafs are collected.
public class CollectibleActivated : MonoBehaviour
{
    [SerializeField] private LeafCollectible leafOne;
    [SerializeField] private LeafCollectible leafTwo;
    [SerializeField] private LeafCollectible leafThree;
    [SerializeField] private float durationAllowed;
    [SerializeField] private GameObject activatedPlatform;
    [SerializeField] private GameObject blockage;

    private bool hasCleared;



    // Start is called before the first frame update
    void Start()
    {
        hasCleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Activate platform if it has not been activated before and when all 3 leaves are collected.
        if (leafOne.hasTaken && leafTwo.hasTaken && leafThree.hasTaken && ! hasCleared)
        {
            activatePlatform();
        }
        //Make all leafs appear if not all of them are collected within the duration allowed
        if (Time.time >= LeafCollectible.startTime + durationAllowed && ! hasCleared)
        {
            activateLeafs();
        }
        
    }


    //Make player-activated platform appear
    private void activatePlatform()
    {
        activatedPlatform.SetActive(true);
        blockage.GetComponent<Animator>().SetTrigger("disappear");
        Invoke("clearBlockage", 2f);

        hasCleared = true;
    }

    //Make all 3 leafs appear
    private void activateLeafs()
    {
        leafOne.makeLeafAppear();
        leafTwo.makeLeafAppear();
        leafThree.makeLeafAppear();
        LeafCollectible.newSet = true;

    }

    //Removes the barrier obstacle
    private void clearBlockage()
    {
        blockage.SetActive(false);    
    }
}
