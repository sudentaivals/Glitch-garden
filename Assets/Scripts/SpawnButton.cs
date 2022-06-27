using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] AudioClip _waveStartSound;
    [SerializeField][Range(0f, 1f)] float _waveStartSoundVolume = 0.5f;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

    }
    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.StartWave, DisableButton);
        GameplayEventBus.Subscribe(GameplayEventType.StartWave, PlayWaveStartSound);
        GameplayEventBus.Subscribe(GameplayEventType.StartMidWave, EnableButton);
        GameplayEventBus.Subscribe(GameplayEventType.GameOver, DisableButton);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.StartWave, DisableButton);
        GameplayEventBus.Unsubscribe(GameplayEventType.StartWave, PlayWaveStartSound);
        GameplayEventBus.Unsubscribe(GameplayEventType.StartMidWave, EnableButton);
        GameplayEventBus.Unsubscribe(GameplayEventType.GameOver, DisableButton);
    }

    private void PlayWaveStartSound(GameObject sender)
    {
        SoundManager.Instance.PlayClip(_waveStartSoundVolume, _waveStartSound);
    }

    private void DisableButton(GameObject sender)
    {
        _button.interactable = false;
    }

    private void EnableButton(GameObject sender)
    {
        _button.interactable = true;
    }

}
