using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class represents a portal from the portal gun
public class Portal : MonoBehaviour
{
    static Portal[] portalArray = new Portal[2];
    private static Portal holder;

    private static Portal toDestroy;

    private void Awake()
    {
        holder = this;
    }

    public static void createPortal(Portal portalToCreate)
    {
        if (portalArray[0] == null && portalArray[1] == null)
        {
            //There is no portal
            portalArray[0] = portalToCreate;
        }
        else if (portalArray[1] == null)
        {
            //There is only 1 portal
            portalArray[1] = portalToCreate;
        } else {
            //There are 2 portals
            destroyOnePortal(portalArray[0]);
            portalArray[0] = portalArray[1];
            portalArray[1] = portalToCreate;
        }
    }

    private void destoryAllPortals()
    {
        if (portalArray[0] == null && portalArray[1] == null)
        {
            //There is no portal
        }
        else if (portalArray[1] == null)
        {
            portalArray[0].GetComponent<Animator>().SetBool("destroy", true);
        } else {
            portalArray[0].GetComponent<Animator>().SetBool("destroy", true);
            portalArray[1].GetComponent<Animator>().SetBool("destroy", true);
        }
        Invoke("destroyPortals", 0.07f);
    }

    public static void destroyPortals()
    {
        for (int i = 0; i < 2; i = i + 1)
        {
            if (portalArray[i] != null)
            {
                Destroy(portalArray[i].gameObject);
                portalArray[i] = null;
            }
        }
    }

    private static void destroyOnePortal(Portal portalToDestroy)
    {
        portalToDestroy.GetComponent<Animator>().SetBool("destroy", true);
        toDestroy = portalToDestroy;
        holder.Invoke("toDestroyPortal", 1f);
    }

    private void toDestroyPortal()
    {
        Destroy(toDestroy.gameObject);
    }

}
