using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = @"Actions/Play SFX")]
public class PlaySFXAction : BaseAction
{
    [SerializeField] AudioClip sfx;
    [SerializeField] [Range(0f, 1f)] float sfxVolume = 0.5f;
    public override void TriggertAction(GameObject target, GameObject souce)
    {
        if (sfx != null)
        {
            //AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position, sfxVolume);
            SoundManager.Instance.PlayClip(sfxVolume, sfx);
        }
    }

}
