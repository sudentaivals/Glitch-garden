using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSlider : MonoBehaviour
{
    Slider _slider;

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.StartWave, SetTimer);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.StartWave, SetTimer);
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void SetTimer(GameObject sender)
    {
        if (sender.TryGetComponent<WaveManager>( out var waveManager))
        {
            _slider.maxValue = waveManager.CurrentWaveDuration;
            _slider.value = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_slider.value <= _slider.maxValue) _slider.value += Time.deltaTime;
    }
}
