using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class UIAction : ScriptableObject
{
    [SerializeField] List<Sprite> _buttonSprites;
    [SerializeField] List<float> _buttonAngle;
    protected GameObject _owner;
    private List<UnityAction> _actions;
    public List<UnityAction> ActionList
    {
        get
        {
            if (_actions == null)
            {
                _actions = GenerateActions();
            }
            return _actions;
        }
    }

    public void RemoveAction(int index)
    {
        _actions[index] = null;
    }

    public List<Sprite> ButtonSprites => _buttonSprites;
    public List<float> ButtonAngles => _buttonAngle;

    public void SetGameObject(GameObject owner)
    {
        _owner = owner;
    }
    protected abstract List<UnityAction> GenerateActions();

}
