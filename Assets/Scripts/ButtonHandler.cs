using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void LoadNextLevel()
    {
        LevelLoader.Instance.LoadNextScene();
    }

    public void LoadMainMenu()
    {
        LevelLoader.Instance.LoadMainMenu();
    }

    public void RestartLevel()
    {
        LevelLoader.Instance.RestartLevel();

    }

    public void LoadOptions()
    {
        LevelLoader.Instance.LoadConcreteScene("Options");
    }

    public void StartGame()
    {
        LevelLoader.Instance.LoadConcreteScene("Gameplay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        GameplayEventBus.Publish(GameplayEventType.ClosePauseMenu, gameObject);
    }

    public void OpenPauseMenu()
    {
        GameplayEventBus.Publish(GameplayEventType.OpenPauseMenu, gameObject);
    }

}
