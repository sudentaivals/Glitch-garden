using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.PauseGame, PauseGame);
        GameplayEventBus.Subscribe(GameplayEventType.UnpauseGame, UnpauseGame);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.PauseGame, PauseGame);
        GameplayEventBus.Unsubscribe(GameplayEventType.UnpauseGame, UnpauseGame);
    }

    private void Start()
    {
        UnpauseGame(gameObject);
    }

    private void PauseGame(GameObject sender)
    {
        Time.timeScale = 0;
    }

    private void UnpauseGame(GameObject sender)
    {
        Time.timeScale = 1;
    }

}
