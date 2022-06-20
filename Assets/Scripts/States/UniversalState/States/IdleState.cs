using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"State/Idle")]
public class IdleState : BaseUniversalState
{
    public override string Name => "Idle";

    public override bool HasExitTime => false;

    public override void EnableStateAction()
    {
    }

    public override void EndStateAction()
    {
    }

    public override bool StateConditions()
    {
        return true;
    }

    public override void UpdateStateAction()
    {
    }
}
