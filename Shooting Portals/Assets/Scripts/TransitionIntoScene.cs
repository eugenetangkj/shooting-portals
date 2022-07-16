using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class allows for transition into a next scene.
public class TransitionIntoScene : MonoBehaviour
{
    [SerializeField] private string sceneToTransitionInto; //Name of the scene to transition into

    public void goIntoScene()
    {
        SceneManager.LoadScene(sceneToTransitionInto);
    }
}
