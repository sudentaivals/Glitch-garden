using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColliderObject : MonoBehaviour
{
    [SerializeField] List<StatusEffectShell> _effectsOnCollide;
    [SerializeField] List<BaseAction> _actionsOnCollide;
    [SerializeField] int _numberOfCollides = 1;

    public List<StatusEffectShell> EffectsOnCollide => _effectsOnCollide;
    public List<BaseAction> ActionsOnCollide => _actionsOnCollide;


    public void Hit()
    {
        _numberOfCollides--;
        if(_numberOfCollides <= 0)
        {
            Destroy(gameObject);
        }
    }



}
