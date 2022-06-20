using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveColliderObject : MonoBehaviour
{

    private SecondaryStats _stats;

    private void Start()
    {
        _stats = GetComponent<SecondaryStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ActiveColliderObject>() == null) return;
        var activeObjectSecondStats = collision.gameObject.GetComponent<SecondaryStats>();
        if (_stats._side != activeObjectSecondStats._side)
        {
            ActiveColliderObject damageDealer = collision.GetComponent<ActiveColliderObject>();
            ApplyStatusEffects(damageDealer);
            ApplyActions(damageDealer);
            damageDealer.Hit();

        }
    }

    private void ApplyActions(ActiveColliderObject damageDealer)
    {
        if (damageDealer.ActionsOnCollide == null) return;
        foreach (var action in damageDealer.ActionsOnCollide)
        {
            action?.TriggertAction(gameObject, damageDealer.gameObject);
        }
    }

    private void ApplyStatusEffects(ActiveColliderObject damageDealer)
    {
        if (damageDealer.EffectsOnCollide == null) return;
        bool tryGetComponent = TryGetComponent<StatusEffectManager>(out StatusEffectManager healthObjecteffectManager);
        if (tryGetComponent)
        {
            foreach (var effect in damageDealer.EffectsOnCollide)
            {
                healthObjecteffectManager.AddNewEffect(effect);
            }
        }

    }
}

