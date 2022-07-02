using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionIntoScene : MonoBehaviour
{
    [SerializeField] private string sceneToTransitionInto;

    public void goIntoScene()
    {
        SceneManager.LoadScene(sceneToTransitionInto);
    }
}
