using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            intermediateDisappear = intermediateDisappear && orb.hasTouched;
        }
        if (intermediateDisappear)
        {
            platformToAppear.SetActive(true);

        }
    }

}
