using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _heartsCost = 1;

    public int HeartsCost => _heartsCost;

    public void ActionsOnArrival()
    {
        GameplayEventBus.Publish(GameplayEventType.ChangeLives, gameObject);
        Destroy(gameObject);
    }
}
