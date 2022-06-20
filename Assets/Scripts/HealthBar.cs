using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Gradient _gradient;
    [SerializeField] Image _barImage;
    HealthSystem _parentHealth;
    Slider _bar;

    void Start()
    {
        _parentHealth = transform.parent.GetComponent<HealthSystem>();
        _bar = transform.Find("HealthBar").gameObject.GetComponent<Slider>();
        _barImage.color = _gradient.Evaluate(1f);
    }

    private void Update()
    {
        _bar.value = _parentHealth.CurrentHealthPercent;
        _barImage.color = _gradient.Evaluate(_parentHealth.CurrentHealthPercent);
    }

}
