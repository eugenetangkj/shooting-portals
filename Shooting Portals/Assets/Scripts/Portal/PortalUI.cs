using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class handles the logic of syncing the Portal Count UI with the Portal class
public class PortalUI : MonoBehaviour
{
    [SerializeField] private Image portalOne;
    [SerializeField] private Image portalTwo;

    private static Image portalOneUI;

    private static Image portalTwoUI;

    private void Start()
    {
       portalOneUI = portalOne;
       portalTwoUI = portalTwo; 
    }

    public static void makePortalOneAppear()
    {
        portalOneUI.GetComponent<Image>().color = new Color(1f, 1f, 1f, 75f / 255f);
    }

    public static void makePortalTwoAppear()
    {
        portalTwoUI.GetComponent<Image>().color = new Color(1f, 1f, 1f, 75f / 255f);
    }

    public static void makePortalsDisappear()
    {
        portalOneUI.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        portalTwoUI.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }

    public static void makePortalTwoDisappear()
    {
        portalTwoUI.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }
}
