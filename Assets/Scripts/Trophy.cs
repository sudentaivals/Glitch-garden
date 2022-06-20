using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] int _resourcesPerCycle;
    [SerializeField] GameObject _star;
    private bool _isEnabled = false;
    public void AddResource()
    {
        if (!_isEnabled) return;
        var starManager = FindObjectOfType<StarsManager>();
        starManager.AddStars(_resourcesPerCycle);
        if (_star != null)
        {
            var star = Instantiate(_star, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            Destroy(star, 1f);
        }
    }

    private void Start()
    {
        var enemySpawner = FindObjectOfType<WaveManager>();
        if (enemySpawner.CurrentSpawnerState == EnemySpawnerState.NotSpawning || enemySpawner.CurrentSpawnerState == EnemySpawnerState.Finish)
        {
            _isEnabled = false;
        }
        else
        {
            _isEnabled = true;
        }

    }

    private void StartMiningStars(GameObject sender)
    {
        _isEnabled = true;
    }

    private void StopMiningStars(GameObject sender)
    {
        _isEnabled = false;
    }

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.StartMidWave, StopMiningStars);
        GameplayEventBus.Subscribe(GameplayEventType.StartWave, StartMiningStars);

    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.StartMidWave, StopMiningStars);
        GameplayEventBus.Unsubscribe(GameplayEventType.StartWave, StartMiningStars);
    }
}
