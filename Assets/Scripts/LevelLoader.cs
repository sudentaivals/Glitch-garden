using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Singleton<LevelLoader>
{
    public void LoadSceneWithDelay(string sceneName, float delay)
    {
        Time.timeScale = 1;
        StartCoroutine(ChangeLevelDelay(sceneName, delay)) ;
    }

    private IEnumerator ChangeLevelDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCountInBuildSettings - 1)
        {
            LoadMainMenu();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
