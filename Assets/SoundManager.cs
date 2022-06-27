using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private List<AudioSource> _audioSources;
    public float SoundVolume
    {
        get
        {
            return _soundMasterVolume;
        }
        set
        {
            _soundMasterVolume = value;
            foreach (var source in _audioSources)
            {
                source.volume = _soundMasterVolume;
            }
        }
    }


    private float _soundMasterVolume;

    public override void Awake()
    {
        base.Awake();
        _audioSources = new List<AudioSource>();
        SoundVolume = PlayerPrefsController.SfxVolume;
    }

    public void PlayClip(float volume, AudioClip clip)
    {
        var availableSources = _audioSources.FirstOrDefault(a => !a.isPlaying);
        if(availableSources == null)
        {
            var newSource = AddNewSource();
            newSource.clip = clip;
            newSource.volume = volume * SoundVolume;
            newSource.Play();
        }
        else
        {
            availableSources.clip = clip;
            availableSources.volume = volume * SoundVolume;
            availableSources.Play();
        }
    }

    private AudioSource AddNewSource()
    {
        var newAudioSource = gameObject.AddComponent<AudioSource>();
        newAudioSource.playOnAwake = false;
        newAudioSource.volume = SoundVolume;
        _audioSources.Add(newAudioSource);
        return newAudioSource;
    }

}
