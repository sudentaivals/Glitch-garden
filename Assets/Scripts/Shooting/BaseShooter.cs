using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShooter : MonoBehaviour
{
    [SerializeField]protected GameObject _projectile;
    [SerializeField] float _baseCooldown;
    [Header("SFX")]
    [SerializeField] AudioClip _spawnClip;
    [SerializeField] [Range(0f, 1f)] float _spawnSoundVolume = 0.5f;
    [Header("Shooting range")]
    [SerializeField][Range(0f, 9f)] float _shootingAreaWidth = 9f;
    [SerializeField][Range(0f, 9f)] float _shootiongAreaHeight = 0.75f;
    [SerializeField] bool headingRightDirection = true;

    private ShootingArea _shootingArea;

    public bool IsEnemyInRange => _shootingArea.IsEnemyInRange;

    private float _currentCooldown;

    protected Transform _gun;

    public bool IsShootReady => _currentCooldown <= 0;

    protected virtual void Start()
    {
        _gun = transform.Find("Gun");
        CreateArea();
        _currentCooldown = _baseCooldown;
    }

    private void CreateArea()
    {
        var area = new GameObject("ShootingArea");
        area.transform.parent = gameObject.transform;
        area.transform.localPosition = new Vector3(0, 0, 2.5f);
        var box = area.AddComponent<BoxCollider2D>();
        box.size = new Vector2(_shootingAreaWidth, _shootiongAreaHeight);
        box.offset = headingRightDirection ? new Vector2(_shootingAreaWidth / 2, 0) : new Vector2(-_shootingAreaWidth / 2, 0);
        var rb = area.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
         _shootingArea = area.AddComponent<ShootingArea>();

    }

    private void Update()
    {
        if(_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        if (IsShootReady)
        {
            if (_spawnClip != null) AudioSource.PlayClipAtPoint(_spawnClip, Camera.main.transform.position, _spawnSoundVolume);
            Shoot();
            _currentCooldown = _baseCooldown;
        }
    }

    protected abstract void Shoot();

}
