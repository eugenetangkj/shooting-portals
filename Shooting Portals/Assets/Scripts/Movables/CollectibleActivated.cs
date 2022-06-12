using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (leafOne.hasTaken && leafTwo.hasTaken && leafThree.hasTaken && ! hasCleared)
        {
            activatePlatform();
        }
        if (Time.time >= LeafCollectible.startTime + durationAllowed && ! hasCleared)
        {
            activateLeafs();
        }
        
    }


    private void activatePlatform()
    {
        activatedPlatform.SetActive(true);
        blockage.GetComponent<Animator>().SetTrigger("disappear");
        Invoke("clearBlockage", 2f);

        hasCleared = true;
    }

    private void activateLeafs()
    {
        leafOne.makeLeafAppear();
        leafTwo.makeLeafAppear();
        leafThree.makeLeafAppear();
        LeafCollectible.newSet = true;

    }

    private void clearBlockage()
    {
        blockage.SetActive(false);    
    }
}
