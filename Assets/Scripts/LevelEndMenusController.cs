using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndMenusController : MonoBehaviour
{
    [SerializeField] GameObject _levelLostMenu;
    [SerializeField] GameObject _levelWonMenu;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] Image _darkScreen;

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.GameOver, GameOver);
        GameplayEventBus.Subscribe(GameplayEventType.LevelComplete, LevelComplete);
        GameplayEventBus.Subscribe(GameplayEventType.OpenPauseMenu, OpenPauseMenu);
        GameplayEventBus.Subscribe(GameplayEventType.ClosePauseMenu, ClosePauseMenu);

    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.GameOver, GameOver);
        GameplayEventBus.Unsubscribe(GameplayEventType.LevelComplete, LevelComplete);
        GameplayEventBus.Unsubscribe(GameplayEventType.OpenPauseMenu, OpenPauseMenu);
        GameplayEventBus.Unsubscribe(GameplayEventType.ClosePauseMenu, ClosePauseMenu);
    }

    private void Start()
    {
        _darkScreen.gameObject.SetActive(false);

    }

    private void GameOver(GameObject sender)
    {
        _levelLostMenu.SetActive(true);
        _darkScreen.gameObject.SetActive(true);
        GameplayEventBus.Publish(GameplayEventType.PauseGame, gameObject);
        GameplayEventBus.Publish(GameplayEventType.DestroyAllProjectiles, gameObject);
    }

    private void LevelComplete(GameObject sender)
    {
        _levelWonMenu.SetActive(true);
        _darkScreen.gameObject.SetActive(true);
        GameplayEventBus.Publish(GameplayEventType.PauseGame, gameObject);
        GameplayEventBus.Publish(GameplayEventType.DestroyAllProjectiles, gameObject);
    }

    private void OpenPauseMenu(GameObject sender)
    {
        _pauseMenu.SetActive(true);
        _darkScreen.gameObject.SetActive(true);
        GameplayEventBus.Publish(GameplayEventType.PauseGame, gameObject);
    }

    private void ClosePauseMenu(GameObject sender)
    {
        _pauseMenu.SetActive(false);
        _darkScreen.gameObject.SetActive(false);
        GameplayEventBus.Publish(GameplayEventType.UnpauseGame, gameObject);
    }
}
