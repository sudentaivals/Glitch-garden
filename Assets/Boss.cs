using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Material _bossMaterial;

    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        var material = new Material(_bossMaterial);
        material.SetColor("_Color", new Color(1, 0, 0, 1));
        material.SetFloat("_Thickness", 1f);
        _spriteRenderer = transform.Find("Body").gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.material = material;
    }

}
