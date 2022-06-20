using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = @"State/Attack")]

public class AttackState : BaseUniversalState
{
    private Melee _melee;
    public override string Name => "Attack";

    public override bool HasExitTime => true;

    public override void SetGameObject(GameObject newOwner, UniversalController controller)
    {
        base.SetGameObject(newOwner, controller);
        if (_stateOwner.TryGetComponent<Melee>(out var melee))
        {
            _melee = melee;
        }
        else
        {
            throw new UnityException($"Melee component not found at [{_stateOwner}] unit");
        }

    }
    public override void EnableStateAction()
    {
        _melee.DamageTaker = _controller.EnemiesInRange.First(a => a != null);
    }

    public override void EndStateAction()
    {

    }

    public override bool StateConditions()
    {
        if(_melee.IsKickReady && _controller.IsCollidedWithEnemy)
        {
            return true;
        }
        return false;
    }

    public override void UpdateStateAction()
    {

    }
}
