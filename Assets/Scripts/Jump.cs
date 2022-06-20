using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] int _jumpsAwailable = 1;
    [SerializeField] float _velocity = 3.5f;
    [SerializeField] float _jumpLenght = 3f;

    private Vector2 _jumpPoint = Vector2.zero;


    public bool IsJumpAvailable => _jumpsAwailable > 0;
    public void StartJump()
    {
        _jumpsAwailable--;
        _jumpPoint = CalculateJumpPosition();
    }

    public void MoveTowards()
    {
        transform.position = Vector2.MoveTowards(transform.position, _jumpPoint, _velocity * Time.deltaTime);
    }

    private Vector2 CalculateJumpPosition()
    {
        var newX = Mathf.RoundToInt(transform.position.x) - _jumpLenght;
        return new Vector2(newX, transform.position.y);
    }
}
