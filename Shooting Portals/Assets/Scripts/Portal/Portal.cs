using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This class represents a portal from the portal gun
public class Portal : MonoBehaviour
{
    static Portal[] portalArray = new Portal[2];

    private static Portal holder;

    private static Portal toDestroy;

    public static bool inContactWithPlayer;

    private static Portal portalInContact;

    public static Portal portalToTeleportTo;

    public static float portalOneShootDirection;

    public static float portalTwoShootDirection;

    public static int portalCount = 0;

    public static bool gotBlock = false;

    [SerializeField] LayerMask movableLayer;


    private void Awake()
    {
        holder = this;
    }

    void OnTriggerEnter2D(Collider2D objectHit)
    {
        if (objectHit.tag == "Player" && portalArray[1] != null)
        {
            Invoke("setContactToTrue", 0.1f);
            portalInContact =  this;
            getPortalToTeleportTo(portalInContact);

            gotBlock = Physics2D.OverlapCircle(portalToTeleportTo.transform.position, 1.85f, movableLayer);
                     
        }
    }

    void OnTriggerExit2D(Collider2D objectHit)
    {
        if (objectHit.tag == "Player")
        {
            inContactWithPlayer = false;
        }
    }

    private void setContactToTrue()
    {
        inContactWithPlayer = true;
    }

    public static void createPortal(Portal portalToCreate)
    {
        if (portalArray[0] == null && portalArray[1] == null)
        {
            //There is no portal
            portalArray[0] = portalToCreate;
            portalArray[0].tag = "Portal 1";
            portalCount = portalCount + 1;
            PortalUI.makePortalOneAppear();
        }
        else if (portalArray[1] == null)
        {
            //There is only 1 portal
            portalArray[1] = portalToCreate;
            portalArray[1].tag = "Portal 2";
            portalCount = portalCount + 1;
            PortalUI.makePortalTwoAppear();
        } else {
            //There are 2 portals
            destroyOnePortal(portalArray[0]);
            portalArray[0] = portalArray[1];
            portalArray[0].tag = "Portal 1";
            portalArray[1] = portalToCreate;
            portalArray[1].tag = "Portal 2";
        }
    }

    public static void destroyAllPortals()
    {
        if (portalArray[0] == null && portalArray[1] == null)
        {
            //There is no portal
        }
        else if (portalArray[1] == null)
        {
            portalArray[0].GetComponent<Animator>().SetBool("destroy", true);
            holder.Invoke("destroyPortals", 1f);
        } else {
            portalArray[0].GetComponent<Animator>().SetBool("destroy", true);
            portalArray[1].GetComponent<Animator>().SetBool("destroy", true);
            holder.Invoke("destroyPortals", 1f);
        }
        PortalUI.makePortalsDisappear();
        portalCount = 0;
    }

    private void destroyPortals()
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


    private void getPortalToTeleportTo(Portal from)
    {
        if (from.tag == "Portal 1")
        {
            portalToTeleportTo = portalArray[1];
        } else if (from.tag == "Portal 2") {
            portalToTeleportTo = portalArray[0];
        }
    }

    public static Vector2 getPositionToTeleport()
    {
        return portalToTeleportTo.transform.position;
    }

}
