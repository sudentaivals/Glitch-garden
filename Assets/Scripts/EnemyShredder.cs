using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.ActionsOnArrival();
        }
    }
}
