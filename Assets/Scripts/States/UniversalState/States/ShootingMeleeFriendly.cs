using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"State/ShootWithMelee")]
public class ShootingMeleeFriendly : BaseUniversalState
{
    private BaseShooter _shooter;
    public override string Name => "Shoot";

    public override bool HasExitTime => true;


    public override void SetGameObject(GameObject newOwner, UniversalController controller)
    {
        base.SetGameObject(newOwner, controller);
        if (_stateOwner.TryGetComponent<BaseShooter>(out var shooter))
        {
            _shooter = shooter;
        }
        else
        {
            throw new UnityException($"shooter component not found at [{_stateOwner}] unit");
        }

    }

    public override void EnableStateAction()
    {

    }

    public override void EndStateAction()
    {

    }

    public override bool StateConditions()
    {
        return _shooter.IsShootReady && _shooter.IsEnemyInRange;
    }

    public override void UpdateStateAction()
    {

    }
}
