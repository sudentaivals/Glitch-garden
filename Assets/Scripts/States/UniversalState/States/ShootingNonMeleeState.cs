using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingNonMeleeState : BaseUniversalState
{
    public override string Name => "Shoot";

    public override bool HasExitTime => true;

    public override void EnableStateAction()
    {

    }

    public override void EndStateAction()
    {

    }

    public override bool StateConditions()
    {
        return false;
    }

    public override void UpdateStateAction()
    {

    }
}
