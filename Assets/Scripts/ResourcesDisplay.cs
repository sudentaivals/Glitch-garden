using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] FloatingText _floatingText;

    private int _currentStarsValue = 0;

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.ChangeStarsOnDisplay, UpdateDisplay);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.ChangeStarsOnDisplay, UpdateDisplay);
    }

    private void Start()
    {

    }

    private void UpdateDisplay(GameObject sender)
    {
        if(sender.TryGetComponent<StarsManager>(out var starsManager))
        {
            SpawnFloatingText(starsManager.CurrentStars - _currentStarsValue);
            _currentStarsValue = starsManager.CurrentStars;
            _text.text = starsManager.CurrentStars.ToString();
        }
    }

    private void SpawnFloatingText(int scoreSpawn)
    {
        var text = Instantiate(_floatingText, _text.transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity);
        text.GetComponent<TextMeshPro>().text = scoreSpawn < 0 ? scoreSpawn.ToString() : "+" + scoreSpawn.ToString();

    }

}
