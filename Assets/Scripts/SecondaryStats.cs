using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum UnitSide
{
    Player,
    Enemy
}

public class SecondaryStats : MonoBehaviour
{
    [SerializeField] public UnitSide _side = UnitSide.Enemy;
    public Color BaseColor { get; private set; } = Color.white;


    private void Start()
    {
        BaseColor = FindStartColor();
    }

    private Color FindStartColor()
    {
        if (gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
        {
            return sr.color;
        }
        else
        {
            foreach (Transform tr in gameObject.transform)
            {
                if(tr.gameObject.TryGetComponent<SpriteRenderer>(out var childSr))
                {
                    return childSr.color;
                }
            }
            return Color.white;
        }
    }

}
