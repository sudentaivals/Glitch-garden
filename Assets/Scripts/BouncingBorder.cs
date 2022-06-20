using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBorder : MonoBehaviour
{
    [SerializeField] Vector2 _normalVector = Vector2.down;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bounce")
        {
            var oldDirection = collision.GetComponent<Movement>().Direction;
            collision.GetComponent<Movement>().ChangeDirection(Bounce(oldDirection));
        }
    }

    private Vector2 Bounce(Vector2 oldDirection)
    {
        return oldDirection - 2 * (Vector2.Dot(_normalVector, oldDirection)) * _normalVector;
    }
}
