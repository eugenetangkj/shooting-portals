using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//This class handles the functionality for Reset All button in the Controls section of the pause menu.
public class ResetAllBindings : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActions;

    //Resets all bindings
    public void ResetAllBindingsAction()
    {
        foreach (InputActionMap map in inputActions.actionMaps)
        {
            map.RemoveAllBindingOverrides(); 
        }
        PlayerPrefs.DeleteKey("rebinds");
    }

}
