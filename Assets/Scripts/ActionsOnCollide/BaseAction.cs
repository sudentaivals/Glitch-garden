using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : ScriptableObject
{
    public abstract void TriggertAction(GameObject target, GameObject souce);
}
