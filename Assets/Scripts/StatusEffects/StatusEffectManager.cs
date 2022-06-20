using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public List<ConcreteEffect> Effects { get; private set; }

    void Start()
    {
        Effects = new List<ConcreteEffect>();
    }

    public void AddNewEffect(StatusEffectShell effectShell)
    {
        var effect = gameObject.AddComponent<ConcreteEffect>();
        effect.SetTimer(effectShell.GetDuration());
        effect.StatusName = effectShell.statusName;
        effect._actionOnDestroy+=effectShell.DestroyAction;
        effect._actionsOnStart+=effectShell.StartAction;
        effect._actionsOnUpdate+=effectShell.UpdateAction;
        Effects.Add(effect);
    }

    public void AddNewEffects(List<StatusEffectShell> effectShells)
    {
        foreach (var shell in effectShells)
        {
            if(shell != null) AddNewEffect(shell);
        }
    }
}
