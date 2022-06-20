using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();

    }

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.PauseGame, DisableButton);
        GameplayEventBus.Subscribe(GameplayEventType.UnpauseGame, EnableButton);

    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.PauseGame, DisableButton);
        GameplayEventBus.Unsubscribe(GameplayEventType.UnpauseGame, EnableButton);
    }

    private void DisableButton(GameObject sender)
    {
        _button.interactable = false;
    }

    private void EnableButton(GameObject sender)
    {
        _button.interactable = true;
    }
}
