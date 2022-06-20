using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] float _coolDown;
    [SerializeField] List<BaseAction> _actionsOnCollide;
    [SerializeField] List<StatusEffectShell> _statusEffectsOnCollide;

    public bool IsKickReady => _currentCooldown <= 0;
    public HealthSystem DamageTaker { get; set; }

    private float _currentCooldown = 0;

    public void Attack()
    {
        if(DamageTaker != null && IsKickReady)
        {
            _currentCooldown = _coolDown;
            foreach (var item in _actionsOnCollide)
            {
                item?.TriggertAction(DamageTaker.gameObject, gameObject);
            }
            var statusManager = DamageTaker.GetComponent<StatusEffectManager>();
            statusManager.AddNewEffects(_statusEffectsOnCollide);
        }
    }

    private void Update()
    {
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

}
