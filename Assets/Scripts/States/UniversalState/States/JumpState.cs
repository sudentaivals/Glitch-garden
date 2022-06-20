using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"State/Jump")]

public class JumpState : BaseUniversalState
{
    private Jump _jump;
    public override string Name => "Jump";

    public override bool HasExitTime => true;

    public override void SetGameObject(GameObject newOwner, UniversalController controller)
    {
        base.SetGameObject(newOwner, controller);
        if (_stateOwner.TryGetComponent<Jump>(out var jump))
        {
            _jump = jump;
        }
        else
        {
            throw new UnityException($"Jump component not found at [{_stateOwner}] unit");
        }


    }

    public override void EnableStateAction()
    {
        _stateOwner.GetComponent<BoxCollider2D>().enabled = false;
        _jump.StartJump();
    }

    public override void EndStateAction()
    {
        _stateOwner.GetComponent<BoxCollider2D>().enabled = true;
    }

    public override bool StateConditions()
    {
        return _jump.IsJumpAvailable && _controller.IsCollidedWithEnemy;
    }

    public override void UpdateStateAction()
    {
        _jump.MoveTowards();
    }
}
