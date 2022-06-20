using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"Status/Change speed")]
public class ChangeSpeedEffectShell : StatusEffectShell
{
    [SerializeField] float _deltaSpeed;
    public override void DestroyAction(GameObject target)
    {
        if (target.TryGetComponent<Movement>(out var movement))
        {
            movement.ChangeSpeed(-_deltaSpeed);
        }
    }

    public override void StartAction(GameObject target)
    {
        if(target.TryGetComponent<Movement>(out var movement))
        {
            movement.ChangeSpeed(_deltaSpeed);
        }
    }

    public override void UpdateAction(GameObject target)
    {
        return;
    }
}
