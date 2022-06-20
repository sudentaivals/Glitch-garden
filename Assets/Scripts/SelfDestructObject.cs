using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructObject : MonoBehaviour
{
    [SerializeField] float _lifeTime = 2f;
    // Update is called once per frame
    void Update()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0) Destroy(gameObject);
    }
}
