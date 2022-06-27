using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EnemySpawnerState
{
    Spawning,
    WaitingForClean,
    NotSpawning,
    Finish
}
public class WaveManager : MonoBehaviour
{
    [SerializeField] List<Wave> _waves;
    [SerializeField] float _spawnX = 11;

    public EnemySpawnerState CurrentSpawnerState { get; private set; } = EnemySpawnerState.NotSpawning;
    private int _waveSize;

    public List<int> YIndexList
    {
        get
        {
            return _waves[_currentWaveIndex].SpawnYList;
        }
    }

    public float CurrentWaveDuration => _waves[_currentWaveIndex].DelayList.Sum();

    public int WavesCount => _waves.Count;

    public int CurrentWaveIndex => _currentWaveIndex;

    private int _currentWaveIndex = -1;

    private bool CheckWave()
    {
        if (_waves[_currentWaveIndex] == null) return false;
        return _waves[_currentWaveIndex].DelayList.Count == _waves[_currentWaveIndex].EnemyList.Count && _waves[_currentWaveIndex].EnemyList.Count == _waves[_currentWaveIndex].SpawnYList.Count;
    }

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.GameOver, (a) => Finish());
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.GameOver, (a) => Finish());
    }


    private void Start()
    {
        StartMidWave();
    }

    public void StartWave()
    {
        if (CurrentSpawnerState == EnemySpawnerState.Finish) return;
        GameplayEventBus.Publish(GameplayEventType.StartWave, gameObject);
        MusicManager.Instance.Transition("BattleMusic");
        if (CheckWave())
        {
            CurrentSpawnerState = EnemySpawnerState.Spawning;
            _waveSize = _waves[_currentWaveIndex].DelayList.Count;
            StartCoroutine(SpawnWave());
        }
        else
        {
            throw new UnityException("Wave config collections size error");
        }
    }

    private void Update()
    {
        switch (CurrentSpawnerState)
        {
            case EnemySpawnerState.Spawning:
                break;
            case EnemySpawnerState.NotSpawning:
                break;
            case EnemySpawnerState.Finish:
                break;
            case EnemySpawnerState.WaitingForClean:
                if(transform.childCount > 0)
                {
                    break;
                }
                else
                {
                    StartMidWave();
                }
                break;
            default:
                break;
        }
    }

    private void StartMidWave()
    {
        CurrentSpawnerState = EnemySpawnerState.NotSpawning;
        _currentWaveIndex++;
        if(_currentWaveIndex == _waves.Count)
        {
            Finish();
            GameplayEventBus.Publish(GameplayEventType.LevelComplete, gameObject);
            return;
        }
        GameplayEventBus.Publish(GameplayEventType.StartMidWave, gameObject);
        MusicManager.Instance.Transition("MidwaveMusic");
    }

    private void Finish()
    {
        CurrentSpawnerState = EnemySpawnerState.Finish;
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < _waveSize; i++)
        {
            var position = new Vector3(_spawnX, _waves[_currentWaveIndex].SpawnYList[i], 5);
            SpawnEnemy(_waves[_currentWaveIndex].EnemyList[i], position);
            yield return new WaitForSeconds(_waves[_currentWaveIndex].DelayList[i]);
        }
        CurrentSpawnerState = EnemySpawnerState.WaitingForClean;
    }

    private void SpawnEnemy(GameObject enemy, Vector3 spawnPosition)
    {
        Instantiate(enemy, spawnPosition, Quaternion.identity, gameObject.transform);
    }

}
