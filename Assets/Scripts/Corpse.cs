using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (transform.parent.gameObject.TryGetComponent<SpriteRenderer>(out var sr))
        {
            ActivateCorpse(sr);
        }
        else
        {
            foreach (Transform item in transform.parent.transform)
            {
                if (item.gameObject.TryGetComponent<SpriteRenderer>(out var srChild))
                {
                    ActivateCorpse(srChild);
                    break;
                }
            }
        }
        transform.SetParent(null);
    }

    public void DestroyCorpse()
    {
        Destroy(gameObject);
    }

    private void ActivateCorpse(SpriteRenderer sr)
    {
        _spriteRenderer.sprite = sr.sprite;
        _spriteRenderer.flipX = sr.flipX;
    }
}
