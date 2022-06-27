using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] AudioClip _spawnSound;
    [SerializeField][Range(0f, 1f)] float _spawnSoundVolume = 0.5f;

    private GameObject _spawnObject;

    private StarsManager _starsManager;

    public GameObject SpawnObject => _spawnObject;

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.UIObjectDeactivated, ClearSpawnObject);
        GameplayEventBus.Subscribe(GameplayEventType.PauseGame, ClearSpawnObject);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.UIObjectDeactivated, ClearSpawnObject);
        GameplayEventBus.Unsubscribe(GameplayEventType.PauseGame, ClearSpawnObject);
    }

    private void Start()
    {
        _starsManager = FindObjectOfType<StarsManager>();
    }
    public void SetDefender(GameObject newDefender)
    {
        _spawnObject = newDefender;
    }

    private void ClearSpawnObject(GameObject sender)
    {
        _spawnObject = null;
    }

    private Vector2 SnapToWorld(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private bool TrySpawnDefender()
    {
        if (_spawnObject == null) return false;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseRoundedPosition = SnapToWorld(mousePosition);
        //check square position
        if (!CheckBuildPlace(mouseRoundedPosition)) return false;
        //check price
        var price = _spawnObject.GetComponent<DefenderPrice>().Cost;
        if (_starsManager.TrySpendStars(price))
        {
            Instantiate(_spawnObject, mouseRoundedPosition, Quaternion.identity, gameObject.transform);
            PlaySFX();
            GameplayEventBus.Publish(GameplayEventType.UIObjectDeactivated, gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBuildPlace(Vector2 positionToBuild)
    {
        foreach (Transform child in transform)
        {
            if(Mathf.Approximately(positionToBuild.x, child.position.x) && Mathf.Approximately(positionToBuild.y, child.transform.position.y))
            {
                return false;
            } 
        }
        return true;
    }

    private void OnMouseDown()
    {
        TrySpawnDefender();
    }

    private void PlaySFX()
    {
        if(_spawnSound!=null) SoundManager.Instance.PlayClip(_spawnSoundVolume, _spawnSound);
    }
}
