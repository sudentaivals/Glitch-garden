using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector2 _direction = Vector2.right;
    [SerializeField] float _startSpeed = 1f;
    [SerializeField] float _maxSpeed = 20f;
    [SerializeField] float _minSpeed = 0.1f;
    [SerializeField] bool _autoMovement = true;
    [SerializeField] public bool _isMovementAllowed = true;

    private bool _movedThisFrame = false;

    private float _deltaSpeed;

    public float ActualSpeed => Mathf.Clamp(_startSpeed + _deltaSpeed, _minSpeed, _maxSpeed);

    public Vector2 Direction => _direction;

    private void Start()
    {
        _direction.Normalize();
    }

    public void RootCharacter()
    {
        _isMovementAllowed = false;
    }

    public void UnrootCharacter()
    {
        _isMovementAllowed = true;
    }

    public void ChangeSpeed(float deltaSpeed)
    {
        _deltaSpeed += deltaSpeed;
    }

    public void ChangeDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    public void ChangeDirection(float angleDegree)
    {
        float angleRads = Mathf.Deg2Rad * angleDegree;
        _direction = new Vector2(Mathf.Cos(angleRads), Mathf.Sin(angleRads));
    }

    public void Move()
    {
        if (_isMovementAllowed && !_movedThisFrame)
        {
            transform.Translate(_direction * ActualSpeed * Time.deltaTime, Space.World);
            _movedThisFrame = true;
        }
    }

    void Update()
    {
        if(_autoMovement) Move();
        _movedThisFrame = false;
    }
}
