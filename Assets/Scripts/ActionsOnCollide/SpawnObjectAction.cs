using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnPosition
{
    Target,
    Source
}

[CreateAssetMenu(menuName = @"Actions/Spawn object")]
public class SpawnObjectAction : BaseAction
{
    [SerializeField] GameObject _spawnObject;
    [SerializeField] SpawnPosition _spawnPos;
    [SerializeField] bool _isSpawnedObjectIsChild = false;
    public override void TriggertAction(GameObject target, GameObject souce)
    {
        if (_spawnObject != null)
        {
            Vector2 spawnPos = Vector2.zero;
            Transform parent = null;
            switch (_spawnPos)
            {
                case SpawnPosition.Target:
                    spawnPos = target.transform.position;
                    parent = target.transform;
                    break;
                case SpawnPosition.Source:
                    spawnPos = souce.transform.position;
                    parent = souce.transform;
                    break;
                default:
                    break;
            }
            if (_isSpawnedObjectIsChild)
            {
                Instantiate(_spawnObject, spawnPos, Quaternion.identity, parent);
            }
            else
            {
                Instantiate(_spawnObject, spawnPos, Quaternion.identity);
            }
        }
    }
}
