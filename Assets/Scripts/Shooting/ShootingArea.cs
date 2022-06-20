using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingArea : MonoBehaviour
{
    private int _collisionCount = 0;

    public bool IsEnemyInRange => _collisionCount > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthSystem>() != null && collision.GetComponent<SecondaryStats>()._side != transform.parent.gameObject.GetComponent<SecondaryStats>()._side)
        {
            _collisionCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthSystem>() != null && collision.GetComponent<SecondaryStats>()._side != transform.parent.gameObject.GetComponent<SecondaryStats>()._side)
        {
            _collisionCount--;
        }
    }
}
