using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float _minAngleDegrees;
    [SerializeField] float _maxAngleDegrees;
    [SerializeField] float _speed = 1f;

    public string Text { get; set; } = "BLANK";

    Vector2 _direction;
    TextMeshPro _text;


    void Start()
    {
        _text = GetComponent<TextMeshPro>();
        //_text.text = Text;
        float angle = Random.Range(_minAngleDegrees, _maxAngleDegrees) * Mathf.Deg2Rad;
        _direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    void Update()
    {
        transform.Translate(_direction * Time.unscaledDeltaTime * _speed, Space.Self);
    }

    public void DestroyText()
    {
        Destroy(gameObject);
    }
}
