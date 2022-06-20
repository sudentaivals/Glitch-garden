using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.StartMidWave, UpdateWavesDisplay);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.StartMidWave, UpdateWavesDisplay);
    }
    private void UpdateWavesDisplay(GameObject sender)
    {
        if(sender.TryGetComponent<WaveManager>(out var waveManager))
        {
            _text.text = $"{waveManager.CurrentWaveIndex+1}/{waveManager.WavesCount}";
        }
    }
}
