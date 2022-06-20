using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"State/Spawn mushrooms")]
public class SpawnMushroomsState : BaseUniversalState
{
    public override string Name => "SpawnUnits";

    public override bool HasExitTime => true;

    private MushroomBossSpawn _spawn;

    public override void SetGameObject(GameObject newOwner, UniversalController controller)
    {
        base.SetGameObject(newOwner, controller);

        if (_stateOwner.TryGetComponent<MushroomBossSpawn>(out var spawn))
        {
            _spawn = spawn;
        }
        else
        {
            throw new UnityException($"MushroomBossSpawn component not found at [{_stateOwner}] unit");
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
        return _spawn.IsSpawnReady;
    }

    public override void UpdateStateAction()
    {

    }
}

