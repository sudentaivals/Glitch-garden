using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;


    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.StartWave, DestroyProjectile);
        GameplayEventBus.Subscribe(GameplayEventType.DestroyAllProjectiles, DestroyProjectile);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.StartWave, DestroyProjectile);
        GameplayEventBus.Unsubscribe(GameplayEventType.DestroyAllProjectiles, DestroyProjectile);
    }

    private SecondaryStats _stats;
    private void Start()
    {
        _stats = GetComponent<SecondaryStats>();
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
    }

    private void DestroyProjectile(GameObject sender)
    {
        Destroy(gameObject);
    }

}
