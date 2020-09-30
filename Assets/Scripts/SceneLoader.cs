using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            LoadFirstLevel();
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
