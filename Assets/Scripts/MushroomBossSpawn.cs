using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBossSpawn : MonoBehaviour
{
    [SerializeField] int _numberOfSpawns;
    [SerializeField] Enemy _spawnObject;
    [SerializeField] List<Vector2> _spawnPositions;
    [SerializeField] float _cooldown;
    [SerializeField] ParticleSystem _vfxOnAction;
    private float _currentCooldown;

    private WaveManager _waveManager;

    public bool IsSpawnReady => _currentCooldown <= 0;

    void Start()
    {
        _currentCooldown = _cooldown;
        _waveManager = FindObjectOfType<WaveManager>();
        CheckValues();
    }

    private void CheckValues()
    {
        if(_numberOfSpawns > _spawnPositions.Count)
        {
            throw new UnityException("spawn positions count less than number of spawns!");
        }
    }

    void Update()
    {
        UpdateCooldown();
    }

    private void UpdateCooldown()
    {
        if(_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    public void SpawnEnemies()
    {
        if (IsSpawnReady)
        {
            List<int> spawnIndexes = new List<int>();
            while(spawnIndexes.Count != _numberOfSpawns)
            {
                int index = UnityEngine.Random.Range(0, _spawnPositions.Count);
                if (spawnIndexes.Contains(index))
                {
                    continue;
                }
                else
                {
                    spawnIndexes.Add(index);
                }
            }

            foreach (int index in spawnIndexes)
            {
                Instantiate(_spawnObject, new Vector3(_spawnPositions[index].x, _spawnPositions[index].y), Quaternion.identity, _waveManager.transform);
            }
            if(_vfxOnAction != null) Instantiate(_vfxOnAction, transform.position, _vfxOnAction.transform.rotation);
            _currentCooldown = _cooldown;

        }
    }
}
