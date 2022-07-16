using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the logic of making an inactive GameObject active in the scene once all collectibles in the array have been collected.
public class OrbAppearance : MonoBehaviour
{
    [SerializeField] private Orb[] orbs;
    [SerializeField] private GameObject platformToAppear;



    // Update is called once per frame
    void Update()
    {
        bool intermediateDisappear = true;
        foreach (Orb orb in orbs)
        {
            intermediateDisappear = intermediateDisappear && orb.hasTouched; //False as long as one collectible has yet to be collected
        }
        if (intermediateDisappear)
        {
            platformToAppear.SetActive(true); //Make inactive GameObject active

        }
    }

}
