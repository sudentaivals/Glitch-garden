using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnitActionsCanvas : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] SpriteRenderer _circle;
    [SerializeField] Material _outlineMaterial;

    private Material _startMaterial;
    private bool _isActive = false;
    private GameObject _selectedObject;
    
    private void OnEnable()
    {
        GameplayEventBus.Subscribe(GameplayEventType.ActivateActionsCanvas, ActivateCanvas);
    }

    private void OnDisable()
    {
        GameplayEventBus.Unsubscribe(GameplayEventType.ActivateActionsCanvas, ActivateCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            if (_selectedObject == null) DeactivateCanvas();
            if (Input.GetMouseButtonDown(1))
            {
                DeactivateCanvas();
            }
        }
    }

    private void ActivateCanvas(GameObject sender)
    {
        if (_isActive) return;
        if(sender.TryGetComponent<UIActionsObject>(out var uiActions))
        {
            _selectedObject = sender;
            _startMaterial = GetMaterialFromSelectedObject();
            SetMaterialToSelectedObject(_outlineMaterial);
            _isActive = true;
            transform.position = sender.transform.position;
            for (int i = 0; i < uiActions.ActionClone.ActionList.Count; i++)
            {
                var button = GenerateButton(uiActions.ActionClone.ButtonSprites[i], uiActions.ActionClone.ActionList[i], uiActions.ActionClone.ButtonAngles[i]);
            }
            Instantiate(_circle, transform);
        }
    }

    private Button GenerateButton(Sprite buttonImage, UnityAction action, float angle)
    {
        var button = Instantiate(_button, transform);

        button.GetComponent<Image>().sprite = buttonImage;

        button.onClick.AddListener(action);

        float buttonAngle = Mathf.Deg2Rad * angle;
        Vector2 pos = new Vector2(Mathf.Cos(buttonAngle), Mathf.Sin(buttonAngle)) * 0.75f;
        button.transform.position = transform.position + (Vector3)pos;
        return button;
    }

    private void DeactivateCanvas()
    {
        RemoveChilden();
        _isActive = false;
        SetMaterialToSelectedObject(_startMaterial);
        _selectedObject = null;
        GameplayEventBus.Publish(GameplayEventType.UIObjectDeactivated, gameObject);
    }

    private Material GetMaterialFromSelectedObject()
    {
        if (_selectedObject != null)
        {
            if (_selectedObject.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
            {
                return spriteRenderer.material;
            }
            else
            {
                foreach (Transform tr in _selectedObject.transform)
                {
                    if (tr.gameObject.TryGetComponent<SpriteRenderer>(out var childSpriteRenderer))
                    {
                        return childSpriteRenderer.material;
                    }
                }
            }
        }
        return null;

    }

    private void SetMaterialToSelectedObject(Material material)
    {
        if (_selectedObject != null)
        {
            if (_selectedObject.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
            {
                spriteRenderer.material = material;
            }
            else
            {
                foreach (Transform tr in _selectedObject.transform)
                {
                    if (tr.gameObject.TryGetComponent<SpriteRenderer>(out var childSpriteRenderer))
                    {
                        childSpriteRenderer.material = material;
                    }
                }
            }
        }

    }
    private void RemoveChilden()
    {
        foreach (Transform tr in transform)
        {
            Destroy(tr.gameObject);
        }
    }
}
