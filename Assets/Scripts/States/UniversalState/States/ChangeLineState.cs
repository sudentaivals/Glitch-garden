using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"State/Change line")]
public class ChangeLineState : BaseUniversalState
{
    public override string Name => "ChangeLine";

    public override bool HasExitTime => true;

    private Movement _movement;

    private ChangeLine _changeLine;

    public override void SetGameObject(GameObject newOwner, UniversalController controller)
    {
        base.SetGameObject(newOwner, controller);
        if (_stateOwner.TryGetComponent<Movement>(out var movement))
        {
            _movement = movement;
        }
        else
        {
            throw new UnityException($"Movement component not found at [{_stateOwner}] unit");
        }

        if (_stateOwner.TryGetComponent<ChangeLine>(out var changeLine))
        {
            _changeLine = changeLine;
        }
        else
        {
            throw new UnityException($"ChangeLine component not found at [{_stateOwner}] unit");
        }


    }

    public override void EnableStateAction()
    {
        _stateOwner.GetComponent<BoxCollider2D>().enabled = false;
        _changeLine.StartChangingLine(_stateOwner.transform.position.y);
    }

    public override void EndStateAction()
    {
        _stateOwner.GetComponent<BoxCollider2D>().enabled = true;
    }

    public override bool StateConditions()
    {
        return _changeLine.ChangeLineAvailable && _movement._isMovementAllowed && !_controller.IsCollidedWithEnemy;
    }

    public override void UpdateStateAction()
    {
        _changeLine.MoveTowards();
    }
}
