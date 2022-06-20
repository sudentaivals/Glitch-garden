using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UniversalController : MonoBehaviour
{
    [Tooltip("Put idle state ALWAYS at end!")]
    [SerializeField] List<BaseUniversalState> _startStates;
    [SerializeField] bool _isFirstStateDefault = true;

    private List<BaseUniversalState> _actualStates;
    private BaseUniversalState _currentState;

    private Animator _animator;
    private bool IsAnimationEnded => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !_animator.IsInTransition(0);

    private int _collisionCount = 0;
    public List<HealthSystem> EnemiesInRange { get; private set; }
    public bool IsCollidedWithEnemy => _collisionCount > 0;

    private void Awake()
    {
        EnemiesInRange = new List<HealthSystem>();
        _animator = GetComponent<Animator>();
        SetStates();
    }

    private void Update()
    {
        Transition(SelectNextState());
        _currentState.UpdateStateAction();
    }

    private void SetStates()
    {
        _actualStates = new List<BaseUniversalState>();
        foreach (var state in _startStates)
        {
            var stateClone = Instantiate(state);
            stateClone.SetGameObject(gameObject, this);
            _actualStates.Add(stateClone);
        }
        if (_isFirstStateDefault)
        {
            Transition(_actualStates.First());
        }
        else
        {
            Transition(_actualStates.Last());
        }
    }

    private BaseUniversalState SelectNextState()
    {
        if (_currentState.HasExitTime)
        {
            if (IsAnimationEnded)
            {
                return _actualStates.Last();
            }
            else
            {
                return _currentState;
            }
        }
        foreach (var state in _actualStates)
        {
            if (state.StateConditions())
            {
                return state;
            }
        }

        return _actualStates.Last();


    }

    private void Transition(BaseUniversalState newState)
    {
        if (newState == _currentState) return;
        _currentState?.EndStateAction();

        _currentState = newState;
        _currentState.EnableStateAction();
        _animator.Play(_currentState.Name);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthSystem>() != null && collision.GetComponent<SecondaryStats>()._side != GetComponent<SecondaryStats>()._side)
        {
            _collisionCount++;
            EnemiesInRange.Add(collision.gameObject.GetComponent<HealthSystem>());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthSystem>() != null && collision.GetComponent<SecondaryStats>()._side != GetComponent<SecondaryStats>()._side)
        {
            _collisionCount--;
            EnemiesInRange.Remove(collision.gameObject.GetComponent<HealthSystem>());
        }
    }

    public bool IsEnemyOnField()
    {
        return false;
    }

    public bool IsEnemyOnMyLine()
    {
        return false;
    }


}
