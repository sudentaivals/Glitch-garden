using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverDefender : MonoBehaviour
{
    [SerializeField] float _placeGridXStart = 1;
    [SerializeField] float _placeGridXEnd = 7;
    [SerializeField] float _placeGridYStart = 1;
    [SerializeField] float _placeGridYEnd = 5;
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.UIObjectDeactivated, CancelMouseover);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.UIObjectDeactivated, CancelMouseover);
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(_spriteRenderer.sprite != null)
        {
            //drag
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;

            //transparent position
            foreach (Transform item in transform)
            {
                var snapPos = SnapToWorld(mousePosition);
                float newX = Mathf.Clamp(snapPos.x, _placeGridXStart, _placeGridXEnd);
                float newY = Mathf.Clamp(snapPos.y, _placeGridYStart, _placeGridYEnd);
                item.position = new Vector2(newX, newY);
            }
            //cancel
            if (Input.GetMouseButtonDown(1))
            {
                GameplayEventBus.Publish(GameplayEventType.UIObjectDeactivated, gameObject);
            }
        }
    }

    private Vector2 SnapToWorld(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }


    private void CancelMouseover(GameObject sender)
    {
        _spriteRenderer.sprite = null;
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(false);
            item.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    public void SetSprite(Sprite newSprite)
    {
        _spriteRenderer.sprite = newSprite;
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(true);
            item.GetComponent<SpriteRenderer>().sprite = newSprite;
            item.GetComponent<SpriteRenderer>().flipX = _spriteRenderer.flipX;
        }

    }
}
