using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLine : MonoBehaviour
{
    [SerializeField] float _coolDown = 5;
    [SerializeField] float _maxY = 5;
    [SerializeField] float _minY = 1;
    [SerializeField] bool _isMovingUp = true;
    [SerializeField] float _velocity = 1f;

    private float _currentCooldown;
    private Vector2 _destinationPoint;
    public bool ChangeLineAvailable => _currentCooldown <= 0;
    private void CheckDirection(float currentY)
    {
        if (_isMovingUp)
        {
            if(Mathf.Approximately(currentY, _maxY))
            {
                _isMovingUp = false;
            }
        }
        else
        {
            if (Mathf.Approximately(currentY, _minY))
            {
                _isMovingUp = true;
            }
        }
    }

    public void StartChangingLine(float currentY)
    {
        CheckDirection(currentY);
        float newY;
        if (_isMovingUp)
        {
            newY = Mathf.RoundToInt(transform.position.y) + 1;
        }
        else
        {
            newY = Mathf.RoundToInt(transform.position.y) - 1;
        }
        _destinationPoint = new Vector2(transform.position.x, newY);
        _currentCooldown = _coolDown;
    }

    public void MoveTowards()
    {
        transform.position = Vector2.MoveTowards(transform.position, _destinationPoint, _velocity * Time.deltaTime);
    }


    void Start()
    {
        _currentCooldown = _coolDown;
    }

    void Update()
    {
        if (_currentCooldown > 0) _currentCooldown -= Time.deltaTime;
    }
}
