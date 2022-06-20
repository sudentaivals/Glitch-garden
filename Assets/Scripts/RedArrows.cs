using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedArrows : MonoBehaviour
{
    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.StartWave, DisableAllArrows);
        GameplayEventBus.Subscribe(GameplayEventType.StartMidWave, EnableArrows);

    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.StartWave, DisableAllArrows);
        GameplayEventBus.Unsubscribe(GameplayEventType.StartMidWave, EnableArrows);
    }

    private void EnableArrow(int arrowIndex)
    {
        transform.Find(arrowIndex.ToString()).gameObject.SetActive(true);
    }

    private void DisableAllArrows(GameObject sender)
    {
        foreach (Transform trn in transform)
        {
            trn.gameObject.SetActive(false);
        }
    }

    private void EnableArrows(GameObject sender)
    {
        if(sender.TryGetComponent<WaveManager>(out var attackerSpawner))
        {
            foreach (var index in attackerSpawner.YIndexList)
            {
                EnableArrow(index);
            }
        }
    }

}
