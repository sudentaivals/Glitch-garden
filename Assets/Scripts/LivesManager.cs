using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [SerializeField] int _lives;
    [Header("SFX")]
    [SerializeField] AudioClip _enemyPassSound;
    [SerializeField][Range(0f, 1f)] float _enemyPassSoundVolume = 0.5f;

    public int Lives => _lives;

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.ChangeLives, DecreaseLives);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.ChangeLives, DecreaseLives);

    }

    void Start()
    {
        GameplayEventBus.Publish(GameplayEventType.ChangeLivesOnDisplay, gameObject);
    }

    private void DecreaseLives(int value)
    {
        _lives -= value;
        PlaySound();
        GameplayEventBus.Publish(GameplayEventType.ChangeLivesOnDisplay, gameObject);
        // TODO check for game over
        if(_lives <= 0)
        {
            GameplayEventBus.Publish(GameplayEventType.GameOver, gameObject);
        }
    }

    private void DecreaseLives(GameObject sender)
    {
        if(sender.TryGetComponent<Enemy>(out var enemy))
        {
            DecreaseLives(enemy.HeartsCost);
        }
    }

    private void PlaySound()
    {
        if(_enemyPassSound != null)
        {
            AudioSource.PlayClipAtPoint(_enemyPassSound, Camera.main.transform.position, _enemyPassSoundVolume);
        }
    }

}
