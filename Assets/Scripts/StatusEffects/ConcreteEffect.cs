using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteEffect : MonoBehaviour
{
    public string StatusName { get; set; } = "blank";
    private float _timer;
    public Action<GameObject> _actionsOnStart;
    public Action<GameObject> _actionsOnUpdate;
    public Action<GameObject> _actionOnDestroy;
    public void SetTimer(float timer)
    {
        _timer = timer;
    }

    void Start()
    {
        _actionsOnStart?.Invoke(gameObject);
    }

    void Update()
    {
        _actionsOnUpdate?.Invoke(gameObject);
        CheckTimer();
    }

    private void CheckTimer()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0)
        {
            _actionOnDestroy.Invoke(gameObject);
            Destroy(this);
        }
    }
}
