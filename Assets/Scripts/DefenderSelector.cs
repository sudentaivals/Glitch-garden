using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefenderSelector : MonoBehaviour
{
    [SerializeField] GameObject _defender;
    [SerializeField] Color _disableColor;
    [Tooltip("If you want use your own sprite, put it here. If sets to null, sprite will be taken from defender automatically")]
    [SerializeField] Sprite _defaultSprite;
    [SerializeField] float _spriteHeightUnits = 0.75f;

    private DefenderSpawner _spawner;
    private MouseOverDefender _mouseOverDefender;
    private StarsManager _starsManager;

    private SpriteRenderer _defenderImage;
    private TextMeshPro _priceText;
    private TextMeshPro _description;

    private void Awake()
    {
        _defenderImage = transform.Find("DefenderSprite").gameObject.GetComponent<SpriteRenderer>();
        _priceText = transform.Find("DefenderPrice").gameObject.GetComponent<TextMeshPro>();
        _description = transform.Find("Description").gameObject.GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        SetDefenderSprite();
        SetDefenderPriceText();
        SetDefenderDescriptionText();
        SetSpriteSize();
        _starsManager = FindObjectOfType<StarsManager>();
        _spawner = FindObjectOfType<DefenderSpawner>();
        _mouseOverDefender = FindObjectOfType<MouseOverDefender>();
        _defenderImage.color = _disableColor;
    }

    private void SetDefenderDescriptionText()
    {
        _description.text = _defender.GetComponent<DefenderPrice>().Description;
    }

    private void SetSpriteSize()
    {
        _defenderImage.gameObject.transform.localScale = new Vector3(_spriteHeightUnits / _defenderImage.size.y, _spriteHeightUnits / _defenderImage.size.y, _spriteHeightUnits / _defenderImage.size.y);
    }

    private void SetDefenderPriceText()
    {
        _priceText.text = _defender.GetComponent<DefenderPrice>().Cost.ToString();
    }

    private void SetDefenderSprite()
    {
        SpriteRenderer defenderSpriteRenderer;
        if(_defender.TryGetComponent<SpriteRenderer>(out defenderSpriteRenderer))
        {
            if (_defaultSprite == null)
            {
                _defenderImage.sprite = defenderSpriteRenderer.sprite;
            }
            else
            {
                _defenderImage.sprite = _defaultSprite;
            }
            _defenderImage.flipX = defenderSpriteRenderer.flipX;
        }
        else
        {
            foreach (Transform tr in _defender.transform)
            {
                if (tr.gameObject.TryGetComponent<SpriteRenderer>(out defenderSpriteRenderer))
                {
                    if (_defaultSprite == null)
                    {
                        _defenderImage.sprite = defenderSpriteRenderer.sprite;
                    }
                    else
                    {
                        _defenderImage.sprite = _defaultSprite;
                    }
                    _defenderImage.flipX = defenderSpriteRenderer.flipX;
                    break;
                }
            }
        }
    }

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.UIObjectDeactivated, SetDisableColor);
        GameplayEventBus.Subscribe(GameplayEventType.UIObjectActivated, DisableCollider);
        GameplayEventBus.Subscribe(GameplayEventType.UIObjectDeactivated, EnableCollider);
        GameplayEventBus.Subscribe(GameplayEventType.PauseGame, DisableCollider);
        GameplayEventBus.Subscribe(GameplayEventType.UnpauseGame, EnableCollider);

    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.UIObjectDeactivated, SetDisableColor);
        GameplayEventBus.Unsubscribe(GameplayEventType.UIObjectActivated, DisableCollider);
        GameplayEventBus.Unsubscribe(GameplayEventType.UIObjectDeactivated, EnableCollider);
        GameplayEventBus.Unsubscribe(GameplayEventType.PauseGame, DisableCollider);
        GameplayEventBus.Unsubscribe(GameplayEventType.UnpauseGame, EnableCollider);

    }

    private void SetDisableColor(GameObject sender)
    {
        _defenderImage.color = _disableColor;
    }

    private void DisableCollider(GameObject gameObject)
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void EnableCollider(GameObject gameObject)
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnMouseDown()
    {
        if (_spawner.SpawnObject != null) return;
        if (_starsManager.IsEnoughtStars(_defender.GetComponent<DefenderPrice>().Cost))
        {
            GameplayEventBus.Publish(GameplayEventType.UIObjectActivated, gameObject);
            _defenderImage.color = Color.white;
            _spawner.SetDefender(_defender);
            _mouseOverDefender.GetComponent<SpriteRenderer>().flipX = _defenderImage.flipX;
            _mouseOverDefender.SetSprite(_defenderImage.sprite);
        }
    }

    private void OnMouseEnter()
    {
        _description.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        _description.gameObject.SetActive(false);
    }
}
