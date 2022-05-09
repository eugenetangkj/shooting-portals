using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//This class is used to allow user easily navigate between fields/buttons of the Login Menu.
public class ChangeInput : MonoBehaviour
{
    EventSystem system;
    [SerializeField] private Selectable firstInput; //Prevents error if one presses tab when no field/button is selected
    
    void Start()
    {
        //Gets useful information, like what is the current UI element, and what is next in the navigation
        system = EventSystem.current; 
        firstInput.Select();
        
    }

    void Update()
    {
        if (Input.GetKeyDown("tab") && Input.GetKey("left shift")) //Press tab and left shift to move onto the previous field/button
        {
            //Gets the previous selectable object
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous != null)
            {
                previous.Select();
            }
        }

        else if (Input.GetKeyDown("tab")) //Press tab to move onto the next field/button
        {
            //Gets the next selectable object
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
        
    }
}
