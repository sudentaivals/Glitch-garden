using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffectShell : ScriptableObject
{
    [SerializeField] float duration;
    public Sprite image;
    public string statusName;

    public abstract void StartAction(GameObject target);

    public abstract void UpdateAction(GameObject target);

    public abstract void DestroyAction(GameObject target);

    public virtual float GetDuration()
    {
        return duration;
    }

}
