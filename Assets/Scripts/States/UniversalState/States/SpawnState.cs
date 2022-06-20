using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"State/Spawn")]

public class SpawnState : BaseUniversalState
{
    public override string Name => "Spawn";

    public override bool HasExitTime => true;

    public override void EnableStateAction()
    {
        _stateOwner.GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void EndStateAction()
    {
        _stateOwner.GetComponent<BoxCollider2D>().enabled = true;
    }

    public override bool StateConditions()
    {
        return false;
    }

    public override void UpdateStateAction()
    {
    }
}
