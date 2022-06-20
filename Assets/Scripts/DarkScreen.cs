using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    [SerializeField] float _maxDuration = 2;

    private float _currentDuration;
    [SerializeField] bool _reverse = false;

    private float AlphaColor 
    { get
        {
            if (_reverse)
            {
                return 1f - _alphaColorDeltaPerSec * (_maxDuration - _currentDuration);
            }
            else
            {
                return 0f + _alphaColorDeltaPerSec * (_maxDuration - _currentDuration);
            }
        } 
    }

    private float _alphaColorDeltaPerSec;

    private Image _image;
    void Start()
    {
        _currentDuration = _maxDuration;
        _alphaColorDeltaPerSec =  1 / _maxDuration;
        AddSpriteRenderer();
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, AlphaColor);
    }

    private void AddSpriteRenderer()
    {
        gameObject.transform.position = Vector3.zero;
        _image = gameObject.AddComponent<Image>();
        _image.sprite = Resources.Load<Sprite>("Sprites/darkScreen");
        _image.transform.localScale = new Vector3(100, 100, 1);
    }

    void Update()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, AlphaColor);
        _currentDuration -= Time.deltaTime;
        if(_currentDuration <= 0)
        {
            Destroy(gameObject);
        }

    }
}
