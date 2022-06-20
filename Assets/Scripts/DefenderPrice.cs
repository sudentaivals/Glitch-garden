using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefenderPrice : MonoBehaviour
{
    [SerializeField] ParticleSystem _sellVFX;
    [SerializeField] int _cost = 10;
    [Header("SFX")]
    [SerializeField] AudioClip _sellSFX;
    [SerializeField][Range(0f, 1f)] float _sellSFXVolume = 0.5f;
    [Header("Description")]
    [TextArea(14, 10)][SerializeField] string _description = "blank";

    public int Cost => _cost;

    public string Description => _description;

    public void SellTower()
    {
        //add event -> add stars
        if (_sellVFX != null) Instantiate(_sellVFX, transform.position, Quaternion.identity);
        FindObjectOfType<StarsManager>().AddStars(_cost / 2);
        PlaySFX();
        Destroy(gameObject);
    }

    private void PlaySFX()
    {
        if(_sellSFX != null) AudioSource.PlayClipAtPoint(_sellSFX, Camera.main.transform.position, _sellSFXVolume);
    }
}
