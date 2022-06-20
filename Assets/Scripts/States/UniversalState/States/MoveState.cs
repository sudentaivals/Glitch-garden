using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"State/Move")]
public class MoveState : BaseUniversalState
{
    private Movement _movement;
    public override string Name => "Walk";

    public override bool HasExitTime => false;

    public override void SetGameObject(GameObject newOwner, UniversalController controller)
    {
        base.SetGameObject(newOwner, controller);
        if(_stateOwner.TryGetComponent<Movement>(out var movement))
        {
            _movement = movement;
        }
        else
        {
            throw new UnityException($"Movement component not found at [{_stateOwner}] unit");
        }
    }

    public override void EnableStateAction()
    {
        return;
    }

    public override void EndStateAction()
    {
        return;
    }

    public override bool StateConditions()
    {
        return _movement._isMovementAllowed && !_controller.IsCollidedWithEnemy;
    }

    public override void UpdateStateAction()
    {
        _stateOwner.GetComponent<Movement>().Move();
    }
}
