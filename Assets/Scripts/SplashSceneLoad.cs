using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSceneLoad : MonoBehaviour
{
    [SerializeField] float _loadingDelay = 3f;
    void Start()
    {
        LevelLoader.Instance.LoadSceneWithDelay("StartScene", _loadingDelay);
    }

}
