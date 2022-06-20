using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"Actions/Deal damage")]
public class DealDamageAction : BaseAction
{
    [SerializeField] int damage;

    public override void TriggertAction(GameObject target, GameObject souce)
    {
        if (damage != 0)
        {
            target.GetComponent<HealthSystem>().GetDamage(damage);
        }
    }
}
