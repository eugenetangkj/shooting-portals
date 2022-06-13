using UnityEngine;
using UnityEngine.InputSystem;


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

    public void UpdateKeys()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        PlayerfabLoad.updatePlayerBindings(rebinds);
    }

    public void GetKeys()
    {
        Invoke("GetKeysActual", 0.5f);
    }

    public void GetKeysActual()
    {
        var existingRebinds = PlayerfabLoad.playerBindings;
        if (!string.IsNullOrEmpty(existingRebinds))
        {
            actions.LoadBindingOverridesFromJson(existingRebinds);
        }
    }



}
