using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameplayEventBus
{
    private static readonly IDictionary<GameplayEventType, UnityEvent<GameObject>> Events = new Dictionary<GameplayEventType, UnityEvent<GameObject>>();

    public static void Subscribe(GameplayEventType eventType, UnityAction<GameObject> listener)
    {
        UnityEvent<GameObject> thisEvent;
        if(Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent<GameObject>();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscribe(GameplayEventType eventType, UnityAction<GameObject> listener)
    {
        UnityEvent<GameObject> thisEvent;
        if(Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(GameplayEventType eventType, GameObject sender)
    {
        UnityEvent<GameObject> thisEvent;
        if(Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke(sender);
        }
    }
}
