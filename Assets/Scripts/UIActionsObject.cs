using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIActionsObject : MonoBehaviour
{
    [SerializeField] UIAction _actions;

    public UIAction ActionClone { get; private set; }

    private bool _isInterractive = true;

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.UIObjectActivated, DisableSelect);
        GameplayEventBus.Subscribe(GameplayEventType.UIObjectDeactivated, EnableSelect);

        GameplayEventBus.Subscribe(GameplayEventType.PauseGame, DisableSelect);
        GameplayEventBus.Subscribe(GameplayEventType.UnpauseGame, EnableSelect);

    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.UIObjectActivated, DisableSelect);
        GameplayEventBus.Unsubscribe(GameplayEventType.UIObjectDeactivated, EnableSelect);

        GameplayEventBus.Unsubscribe(GameplayEventType.PauseGame, DisableSelect);
        GameplayEventBus.Unsubscribe(GameplayEventType.UnpauseGame, EnableSelect);

    }

    private void EnableSelect(GameObject sender)
    {
        _isInterractive = true;
    }

    private void DisableSelect(GameObject sender)
    {
        _isInterractive = false;
    }

    void Start()
    {
        if(_actions != null)
        {
            ActionClone = Instantiate(_actions);
            ActionClone.SetGameObject(gameObject);
        }
        else
        {
            throw new UnityException("Actions file not found");
        }
    }

    private void OnMouseDown()
    {
        //publish action with UnitActionCanvas
        if (!_isInterractive) return;
        GameplayEventBus.Publish(GameplayEventType.UIObjectActivated, gameObject);
        GameplayEventBus.Publish(GameplayEventType.ActivateActionsCanvas, gameObject);
    }


}
