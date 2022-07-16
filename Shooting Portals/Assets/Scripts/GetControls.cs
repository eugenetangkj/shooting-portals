using UnityEngine;
using UnityEngine.InputSystem;

//This class handles the logic for saving new player bindings and retrieving previously saved player bindings when the player logs in again
public class GetControls: MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;

    // public void OnEnable()
    // {
    //     var existingRebinds = PlayerfabLoad.playerBindings;

    //     if (!string.IsNullOrEmpty(existingRebinds))
    //         actions.LoadBindingOverridesFromJson(existingRebinds);
    // }

    // public void OnDisable()
    // {
    //     var rebinds = actions.SaveBindingOverridesAsJson();
    //     PlayerfabLoad.updatePlayerBindings(rebinds);
    // }

    //Updates the new key bindings
    public void UpdateKeys()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        PlayerfabLoad.updatePlayerBindings(rebinds);
    }

    public void GetKeys()
    {
        Invoke("GetKeysActual", 1f);
    }

    //Retrieves the player bindings from Playfab
    public void GetKeysActual()
    {
        var existingRebinds = PlayerfabLoad.playerBindings;
        if (!string.IsNullOrEmpty(existingRebinds))
        {
            actions.LoadBindingOverridesFromJson(existingRebinds);
        }
    }



}
