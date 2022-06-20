using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUniversalState : ScriptableObject
{
    protected GameObject _stateOwner;

    protected UniversalController _controller;
    public abstract string Name { get; }

    public abstract bool HasExitTime { get; }
    public virtual void SetGameObject(GameObject newOwner, UniversalController controller)
    {
        _stateOwner = newOwner;
        _controller = controller;
    }

    public abstract bool StateConditions();

    public abstract void EnableStateAction();

    public abstract void UpdateStateAction();

    public abstract void EndStateAction();

}
