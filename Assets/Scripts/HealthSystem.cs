using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    [SerializeField] List<BaseAction> _actionsOnDeath;

    private int _currentHealth;

    public int CurrentHealth => _currentHealth;

    public float CurrentHealthPercent => (float)_currentHealth / (float)_maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void GetDamage(int damage)
    {
        _currentHealth -= damage;
        CreateDamageFloatingText(damage);
        if (_currentHealth <= 0)
        {
            ExecuteActions();
            Destroy(gameObject);
        }
    }

    private void ExecuteActions()
    {
        if (_actionsOnDeath == null) return;
        foreach (var action in _actionsOnDeath)
        {
            action?.TriggertAction(gameObject, gameObject);
        }
    }

    private void CreateDamageFloatingText(int damage)
    {
        var floatingText = Resources.Load<GameObject>(@"Prefabs/FloatingText/FloatingDamageText");
        var text = Instantiate(floatingText, gameObject.transform.position, Quaternion.identity);
        text.GetComponent<TextMeshPro>().text = "-" + damage.ToString();
    }

    private void CreateHealFloatingText(int restoreValue)
    {
        var floatingText = Resources.Load<GameObject>(@"Prefabs/FloatingText/FloatingHealingText");
        var text = Instantiate(floatingText, gameObject.transform.position, Quaternion.identity);
        text.GetComponent<TextMeshPro>().text = "+" + restoreValue.ToString();
    }


    public void RestoreHealth(int restoreValue)
    {
        _currentHealth += restoreValue;
        CreateHealFloatingText(restoreValue);
        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }


}
