using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    SceneLoader loader; 

    private void Awake()
    {
        loader = FindObjectOfType<SceneLoader>();
    }

    public void PlayButton()
    {
        loader.LoadNextLevel();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
