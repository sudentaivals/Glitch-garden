using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarsManager : MonoBehaviour
{
    [SerializeField] int _startNumber = 1000;
    [Header("SFX")]
    [SerializeField] AudioClip _spendSound;
    [SerializeField] AudioClip _transactionDeclainedSound;
    [SerializeField] [Range(0f, 1f)] float _volume; 
    public int CurrentStars
    {
        get
        {
            return _currentStarsNumber;
        }
        private set
        {
            _currentStarsNumber = value;
            GameplayEventBus.Publish(GameplayEventType.ChangeStarsOnDisplay, gameObject);
        }
    }

    private int _currentStarsNumber;

    void Start()
    {
        CurrentStars = _startNumber;
    }

    private void PlaySFX(AudioClip clip)
    {
        SoundManager.Instance.PlayClip(_volume, clip);
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, _volume);
    }

    public bool IsEnoughtStars(int starsToSpend)
    {
        if(_currentStarsNumber - starsToSpend >= 0)
        {
            return true;
        }
        PlaySFX(_transactionDeclainedSound);
        return false;
    }
    public bool TrySpendStars(int spend)
    {
        if(CurrentStars-spend < 0)
        {
            //display message and play sound effect
            return false;
        }
        else
        {
            //sound effect of buying
            CurrentStars -= spend;
            return true;
        }
    }

    public void SpendStars(int spend)
    {
        CurrentStars -= spend;
    }

    public void AddStars(int addValue)
    {
        CurrentStars += addValue;
    }

}
