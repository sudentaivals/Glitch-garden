using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = @"UIActions/Standart defender")]
public class DefaultDefenderUiActions : UIAction
{


    protected override List<UnityAction> GenerateActions()
    {
        var actions = new List<UnityAction>();
        actions.Add(_owner.GetComponent<DefenderPrice>().SellTower);
        return actions;
    }
}
