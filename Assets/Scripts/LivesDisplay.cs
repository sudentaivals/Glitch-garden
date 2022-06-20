using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] FloatingText _floatingText;

    private int _curentLives = 0;

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.ChangeLivesOnDisplay, UpdateLivesDisplay);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.ChangeLivesOnDisplay, UpdateLivesDisplay);
    }

    private void UpdateLivesDisplay(GameObject sender)
    {
        if(sender.TryGetComponent<LivesManager>(out var manager))
        {
            SpawnFloatingText(manager.Lives - _curentLives);
            _curentLives = manager.Lives;
            _text.text = manager.Lives.ToString();
        }
    }
    private void SpawnFloatingText(int scoreSpawn)
    {
        var text = Instantiate(_floatingText, _text.transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity);
        text.GetComponent<TextMeshPro>().text = scoreSpawn < 0 ? scoreSpawn.ToString() : "+" + scoreSpawn.ToString();
    }

}
