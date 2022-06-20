using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] List<GameObject> _enemies;

    [SerializeField][Range(1, 5)] List<int> _spawnY;

    [SerializeField][Range(0.1f, 10f)] List<float> _spawnDelay;

    public List<GameObject> EnemyList => _enemies;

    public List<int> SpawnYList => _spawnY;

    public List<float> DelayList => _spawnDelay;
}
