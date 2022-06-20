using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"Status/Change color")]
public class ChangeColorEffectShell : StatusEffectShell
{
    [SerializeField] Color _newColor;

    public override void DestroyAction(GameObject target)
    {
        var baseColor = target.GetComponent<SecondaryStats>() == null ? Color.white : target.GetComponent<SecondaryStats>().BaseColor;
        if (target.TryGetComponent<SpriteRenderer>(out var renderer))
        {
            renderer.color = baseColor;
        }
        var childrenSprites = target.GetComponentsInChildren<SpriteRenderer>();
        foreach (var childSprite in childrenSprites)
        {
            childSprite.color = baseColor;
        }
    }

    public override void StartAction(GameObject target)
    {
        return;
    }

    public override void UpdateAction(GameObject target)
    {
        if(target.TryGetComponent<SpriteRenderer>(out var renderer))
        {
            renderer.color = _newColor;
        }
        var childrenSprites = target.GetComponentsInChildren<SpriteRenderer>();
        foreach (var childSprite in childrenSprites)
        {
            childSprite.color = _newColor;
        }

    }
}
